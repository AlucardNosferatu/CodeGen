using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;


namespace ACG
{
    internal class CodeGen
    {
        public ArrayList simple_params = new ArrayList();
        public Dictionary<String, String> fixed_params = new Dictionary<String, String>();
        public String proxy_out_func_prefix = "homewlan_";
        public String rfkw_prefix = "rfkw_v2_";
        public String proxy_in_func_prefix = "app_v2_";

        public String proxy_out_api_url = "homewlan/sta/setStaRemark2";
        public String proxy_out_func_path = "utils.api.app_v2.functions.frontpage.set_alias";
        public String proxy_in_func_file = "frontpage";
        public String proxy_url_prefix = "functions/v2/frontpage/";

        public bool is_cmd = false;
        public String cmd_string = "ac_config set -m timeReboot '{}'";
        public String specified_action_name = "";
        public bool need_timestamp = true;
        public bool has_time_dict = true;
        public String time_dict_key = "time";
        public String time_dict_ed_key = "enable_days";
        public String time_dict_sn_key = "start_night";
        public String time_dict_em_key = "end_morning";
        public bool has_end_morning = true;
        public bool get_cmd_result = true;



        public CodeGen()
        {
            if (!this.is_cmd)
            {
                this.need_timestamp = false;
                this.has_time_dict = false;
                this.has_end_morning = false;
                this.get_cmd_result = false;
            }


            this.proxy_out_api_url = "homewlan/sta/setStaRemark2";
            this.proxy_out_func_path = "utils.api.app_v2.functions.frontpage.set_alias";
            this.proxy_in_func_file = "frontpage";
            this.proxy_url_prefix = "functions/v2/frontpage/";
            this.simple_params.Add(value: "remark");
            this.simple_params.Add(value: "staMac");
            this.simple_params.Add(value: "projectId");

            //this.simple_params.Add(value: "version");
            //this.simple_params.Add(value: "groupId");
            //this.simple_params.Add(value: "type");
            //this.simple_params.Add(value: "time");
            //this.simple_params.Add(value: "enable");
            //this.simple_params.Add(value: "tmngtName");
            //this.simple_params.Add(value: "networkId");
            //this.simple_params.Add(value: "subConfigId");
            //this.fixed_params.Add(key: "version", value: "\"1.0.0\"");
            //this.fixed_params.Add(key: "groupId", value: "\"0\"");
            //this.fixed_params.Add(key: "type", value: "\"reboot\"");
            //this.fixed_params.Add(key: "tmngtName", value: "\"sys_reboot\"");
        }
        public String ParseCamel(String camel_string)
        {
            String underscoreLowercase = Regex.Replace(camel_string, @"([A-Z])", "_$1").ToLower();
            return underscoreLowercase;
        }
        private void ProcessActionParams(out string action_name, out ArrayList converted_simple_params)
        {
            if (this.specified_action_name.Length > 0)
            {
                action_name = this.specified_action_name;
            }
            else
            {
                if (this.is_cmd)
                {
                    String[] cmd_as_list = this.cmd_string.Replace(oldValue: " '{}'", "").Replace(oldValue: "-m ", "").Split(separator: ' ');
                    action_name = cmd_as_list[cmd_as_list.Length - 2] + "_" + cmd_as_list[cmd_as_list.Length - 1];
                }
                else
                {
                    String[] proxy_out_api_url_splited = this.proxy_out_api_url.Split('/');
                    action_name = proxy_out_api_url_splited[proxy_out_api_url_splited.Length - 1];
                }
                action_name = this.ParseCamel(camel_string: action_name);
            }
            //converted_simple_params包含time_dict对应的参数名、不包含时间戳
            converted_simple_params = new ArrayList();
            foreach (String param_key in this.simple_params)
            {
                converted_simple_params.Add(value: this.ParseCamel(camel_string: param_key));
            }
        }
        private void FilterTrappedParams(ArrayList converted_simple_params)
        {
            if (this.has_time_dict)
            {
                converted_simple_params.Remove(obj: this.time_dict_key);
                converted_simple_params.Add(value: this.time_dict_ed_key);
                converted_simple_params.Add(value: this.time_dict_sn_key);
                if (this.has_end_morning)
                {
                    converted_simple_params.Add(value: this.time_dict_em_key);
                }
            }
            Array fp_keys = this.fixed_params.Keys.ToArray();
            for (int index = 0; index < fp_keys.Length; index++)
            {
                String fp_key = (String)fp_keys.GetValue(index: index);
                fp_key = this.ParseCamel(camel_string: fp_key);
                converted_simple_params.Remove(obj: fp_key);
            }
            if (this.is_cmd)
            {
                if (!converted_simple_params.Contains(item: "project_id"))
                {
                    converted_simple_params.Add(value: "project_id");
                }
                if (!converted_simple_params.Contains(item: "sn"))
                {
                    converted_simple_params.Add(value: "sn");
                }
            }

        }
        public String ProxyOut_write()
        {
            string action_name;
            ArrayList converted_simple_params;
            ProcessActionParams(out action_name, out converted_simple_params);
            FilterTrappedParams(converted_simple_params: converted_simple_params);

            StringWriter sw = new StringWriter();
            sw.WriteLine("# 此标记表明该代码由TOOL生成");
            sw.WriteLine($"def {this.proxy_out_func_prefix}{action_name}({String.Join(", ", converted_simple_params.ToArray())}):");
            ProcessActionParams(out action_name, out converted_simple_params);
            sw.WriteLine($"    api_name = \"{this.proxy_in_func_prefix}{action_name}\"");
            if (this.is_cmd)
            {
                if (this.cmd_string.EndsWith(value: "'{}'"))
                {
                    if (this.need_timestamp)
                    {
                        sw.WriteLine("    timestamp = str(int(time.time()))");
                    }
                    if (this.has_time_dict)
                    {
                        if (this.has_end_morning)
                        {
                            sw.WriteLine($"    time_dict = compose_time_dict(e_days={this.time_dict_ed_key}, sn={this.time_dict_sn_key}, em={this.time_dict_em_key})");
                        }
                        else
                        {
                            sw.WriteLine($"    time_dict = compose_time_dict(e_days={this.time_dict_ed_key}, sn={this.time_dict_sn_key})");
                        }
                    }
                    sw.WriteLine("    cmd_dict = {");
                    for (int index = 0; index < converted_simple_params.Count; index++)
                    {
                        String param_key = (String)this.simple_params[index];
                        if (param_key.Equals(this.time_dict_key))
                        {
                            sw.WriteLine($"        \"{param_key}\": time_dict,");
                        }
                        else
                        {
                            if (this.fixed_params.ContainsKey(key: param_key))
                            {
                                sw.WriteLine($"        \"{param_key}\": {this.fixed_params[param_key]},");
                            }
                            else
                            {
                                sw.WriteLine($"        \"{param_key}\": {converted_simple_params[index]},");
                            }
                        }
                    }
                    if (this.need_timestamp)
                    {
                        sw.WriteLine("        'configTime': timestamp,");
                        sw.WriteLine("        'currentTime': timestamp,");
                        sw.WriteLine("        'configId': timestamp");
                    }
                    sw.WriteLine("    }");
                    sw.WriteLine("    cmd_str = json.dumps(obj=cmd_dict)");
                    sw.WriteLine($"    cmd = \"{this.cmd_string}\".format(cmd_str)");
                }
                else
                {
                    sw.WriteLine($"    cmd = \"{this.cmd_string}\"");
                }
                sw.WriteLine("    return get_cmd_result(api_name=api_name, project_id=project_id, sn=sn, cmd=cmd)");
            }
            else
            {
                sw.WriteLine($"    url = \"{this.proxy_out_api_url}\"");
                sw.WriteLine("    data = {");
                for (int index = 0; index < converted_simple_params.Count; index++)
                {
                    String param_key = (String)this.simple_params[index];
                    String value;
                    if (this.fixed_params.ContainsKey(key: param_key))
                    {
                        value = this.fixed_params[param_key];
                    }
                    else
                    {
                        value = (String)converted_simple_params[index];
                    }
                    if (index == converted_simple_params.Count - 1)
                    {
                        sw.WriteLine($"        \"{param_key}\": {value}");
                    }
                    else
                    {
                        sw.WriteLine($"        \"{param_key}\": {value},");
                    }
                }
                sw.WriteLine("    }");
                sw.WriteLine("    try:");
                sw.WriteLine("        # noinspection PyUnresolvedReferences");
                sw.WriteLine("        ac = AuthInfoV2.objects.get(active=True)");
                sw.WriteLine("        token = ac.token");
                sw.WriteLine("    except Exception as e:");
                sw.WriteLine("        _ = e");
                sw.WriteLine("        return {}");
                sw.WriteLine("    headers = {");
                sw.WriteLine("        \"Accept\": \"application/json\",");
                sw.WriteLine("        \"Content-Type\": \"application/json\",");
                sw.WriteLine("        \"Authorization\": f\"Bearer {token}\"");
                sw.WriteLine("    }");
                sw.WriteLine("    return req_post(api_name, url, headers=headers, data=data)");
            }
            return sw.ToString();
        }



        public String ProxyIn_write()
        {
            string action_name;
            ArrayList converted_simple_params;
            ProcessActionParams(out action_name, out converted_simple_params);
            FilterTrappedParams(converted_simple_params: converted_simple_params);

            StringWriter sw = new StringWriter();
            sw.WriteLine($"from {this.proxy_out_func_path} import {this.proxy_out_func_prefix}{action_name}");
            sw.WriteLine("# 此标记表明该代码由TOOL生成");
            sw.WriteLine($"def {this.proxy_in_func_prefix}{action_name}(request):");
            sw.WriteLine("    if request.method != \"POST\":");
            sw.WriteLine("        return HttpResponse(status=501)");
            sw.WriteLine("    req_body = json.loads(request.body)");
            for (int index = 0; index < converted_simple_params.Count; index++)
            {
                sw.WriteLine($"    {converted_simple_params[index]} = req_body[\"{converted_simple_params[index]}\"]");
            }
            sw.WriteLine($"    res = {this.proxy_out_func_prefix}{action_name}(");

            for (int index = 0; index < converted_simple_params.Count; index++)
            {
                String param_key = (String)this.simple_params[index];
                sw.WriteLine($"        {converted_simple_params[index]}={converted_simple_params[index]},");
            }
            sw.WriteLine("    )");
            sw.WriteLine("    return response(res)");
            return sw.ToString();
        }
        public String ProxyUrl_write()
        {
            string action_name;
            ArrayList converted_simple_params;
            ProcessActionParams(out action_name, out converted_simple_params);

            StringWriter sw = new StringWriter();
            sw.WriteLine($"from . import {this.proxy_in_func_file}");
            sw.WriteLine("# 此标记表明该代码由TOOL生成");
            sw.WriteLine($"urlpatterns.append(path(\"{this.proxy_url_prefix}{action_name}\", {this.proxy_in_func_file}.{this.proxy_in_func_prefix}{action_name}))");
            return sw.ToString();
        }
        public String RFKeyword_write()
        {
            string action_name;
            ArrayList converted_simple_params;
            ProcessActionParams(out action_name, out converted_simple_params);
            FilterTrappedParams(converted_simple_params: converted_simple_params);

            StringWriter sw = new StringWriter();
            sw.WriteLine("# 此标记表明该代码由TOOL生成");
            sw.WriteLine($"def {this.rfkw_prefix}{action_name}({String.Join(", ", converted_simple_params.ToArray())}):");
            sw.WriteLine("    data = {");
            for (int index = 0; index < converted_simple_params.Count; index++)
            {
                if (index == converted_simple_params.Count - 1)
                {
                    sw.WriteLine($"        \"{converted_simple_params[index]}\": {converted_simple_params[index]}");
                }
                else
                {
                    sw.WriteLine($"        \"{converted_simple_params[index]}\": {converted_simple_params[index]},");
                }
            }
            sw.WriteLine("    }");
            sw.WriteLine($"    req = requests.post(TEST_SERVER + \"/api/{this.proxy_url_prefix}{action_name}\", data=json.dumps(data))");
            sw.WriteLine("    req.close()");
            sw.WriteLine("    req_data = json.loads(req.content)");
            if (this.is_cmd)
            {
                sw.WriteLine("    api_history_printer(req_data[\"data\"][\"sendCmd\"][\"autotest_api_uid\"])");
                if (this.get_cmd_result)
                {
                    sw.WriteLine("    api_history_printer(req_data[\"data\"][\"getCmdResult\"][\"autotest_api_uid\"])");
                }
            }
            else
            {
                sw.WriteLine("    api_history_printer(req_data[\"data\"][\"autotest_api_uid\"])");
            }
            sw.WriteLine("    return req_data[\"data\"]");
            return sw.ToString();
        }


    }
}
