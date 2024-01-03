using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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


        public String ProxyOut_write()
        {
            string action_name;
            ArrayList converted_simple_params;


            StringWriter sw = new StringWriter();
            sw.WriteLine("# 此标记表明该代码由TOOL生成");
            //sw.WriteLine($"def {this.proxy_out_func_prefix}{action_name}({String.Join(", ", converted_simple_params.ToArray())}):");

            //sw.WriteLine($"    api_name = \"{this.proxy_in_func_prefix}{action_name}\"");
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
                    for (int index = 0; index < 2; index++)
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
                                //sw.WriteLine($"        \"{param_key}\": {converted_simple_params[index]},");
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
                for (int index = 0; index < 2; index++)
                {
                    String param_key = (String)this.simple_params[index];
                    String value;
                    if (this.fixed_params.ContainsKey(key: param_key))
                    {
                        value = this.fixed_params[param_key];
                    }
                    else
                    {
                        value = "";
                    }
                    if (index == 1)
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


            StringWriter sw = new StringWriter();
            //sw.WriteLine($"from {this.proxy_out_func_path} import {this.proxy_out_func_prefix}{action_name}");
            sw.WriteLine("# 此标记表明该代码由TOOL生成");
            //sw.WriteLine($"def {this.proxy_in_func_prefix}{action_name}(request):");
            sw.WriteLine("    if request.method != \"POST\":");
            sw.WriteLine("        return HttpResponse(status=501)");
            sw.WriteLine("    req_body = json.loads(request.body)");
            for (int index = 0; index < 2; index++)
            {
                //sw.WriteLine($"    {converted_simple_params[index]} = req_body[\"{converted_simple_params[index]}\"]");
            }
            //sw.WriteLine($"    res = {this.proxy_out_func_prefix}{action_name}(");

            for (int index = 0; index < 2; index++)
            {
                String param_key = (String)this.simple_params[index];
                //sw.WriteLine($"        {converted_simple_params[index]}={converted_simple_params[index]},");
            }
            sw.WriteLine("    )");
            sw.WriteLine("    return response(res)");
            return sw.ToString();
        }
        public String ProxyUrl_write()
        {
            string action_name;
            ArrayList converted_simple_params;


            StringWriter sw = new StringWriter();
            sw.WriteLine($"from . import {this.proxy_in_func_file}");
            sw.WriteLine("# 此标记表明该代码由TOOL生成");
            //sw.WriteLine($"urlpatterns.append(path(\"{this.proxy_url_prefix}{action_name}\", {this.proxy_in_func_file}.{this.proxy_in_func_prefix}{action_name}))");
            return sw.ToString();
        }
        public String RFKeyword_write()
        {
            string action_name;
            ArrayList converted_simple_params;
            StringWriter sw = new StringWriter();
            sw.WriteLine("# 此标记表明该代码由TOOL生成");
            //sw.WriteLine($"def {this.rfkw_prefix}{action_name}({String.Join(", ", converted_simple_params.ToArray())}):");
            sw.WriteLine("    data = {");
            for (int index = 0; index < 2; index++)
            {
                if (index == 1)
                {
                    //sw.WriteLine($"        \"{converted_simple_params[index]}\": {converted_simple_params[index]}");
                }
                else
                {
                    //sw.WriteLine($"        \"{converted_simple_params[index]}\": {converted_simple_params[index]},");
                }
            }
            sw.WriteLine("    }");
            //sw.WriteLine($"    req = requests.post(TEST_SERVER + \"/api/{this.proxy_url_prefix}{action_name}\", data=json.dumps(data))");
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

    public class JsonWriter
    {
        public bool has_timetable;
        public bool has_timestamp;
        public String p_dict_name;
        public ArrayList params_list;
        public String[] converted_params;
        public static String ParseCamel(String camel_string)
        {
            String underscoreLowercase = Regex.Replace(camel_string, @"([A-Z])", "_$1").ToLower();
            return underscoreLowercase;
        }
        public JsonWriter(String p_dict_name, String[] tt_names, String ts_name)
        {
            this.params_list = new ArrayList();
            this.p_dict_name = p_dict_name;
            string json = File.ReadAllText(path: "../../proxy_out.json");
            this.has_timestamp = json.Contains(value: "\"#TS\"");
            this.has_timetable = json.Contains(value: "\"#TD\"");
            this.converted_params = json.Split(separator: "\r\n".ToCharArray(), options: StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < this.converted_params.Length; i++)
            {
                if (i == 0)
                {
                    this.converted_params[i] = this.converted_params[i].Replace("{", p_dict_name + " = {");
                }
                else if (this.converted_params[i].Contains(":"))
                {
                    String param_pair = this.converted_params[i].Replace(" ", "");
                    String key = param_pair.Split(separator: "\":\"".ToCharArray(), options: StringSplitOptions.RemoveEmptyEntries)[0];
                    String val = param_pair.Split(separator: "\":\"".ToCharArray(), options: StringSplitOptions.RemoveEmptyEntries)[1];
                    switch (val)
                    {
                        case "#VAR":
                            key = JsonWriter.ParseCamel(key);
                            int dup_key = -1;
                            while (this.params_list.Contains(key))
                            {
                                dup_key += 1;
                                if (dup_key > 0)
                                {
                                    key = key.Substring(startIndex: 0, length: key.Length - 1);
                                }
                                key = key + dup_key.ToString();
                            }
                            this.params_list.Add(key);
                            this.converted_params[i] = this.converted_params[i].Replace("\"#VAR\"", key);
                            break;
                        case "#TD":
                            this.converted_params[i] = this.converted_params[i].Replace("\"#TD\"", tt_names[0]);
                            for (int j = 1; j < tt_names.Length; j++)
                            {
                                if (!this.params_list.Contains(tt_names[j]))
                                {
                                    this.params_list.Add(tt_names[j]);
                                }
                            }
                            break;
                        case "#TS":
                            this.converted_params[i] = this.converted_params[i].Replace("\"#TS\"", ts_name);
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine(this.converted_params[i]);
            }
        }


    }

}
