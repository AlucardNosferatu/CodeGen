using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
namespace ACG
{
    internal class CodeGen
    {
        //固定参数
        public String proxy_out_func_prefix = "homewlan_";
        public String rfkw_prefix = "rfkw_v2_";
        public String proxy_in_func_prefix = "app_v2_";
        public String cmd_inner_dict_var = "cmd_dict";
        public String plain_req_dict_var = "data";
        public String timestamp_var = "timestamp";
        public String timetable_var = "timetable";
        public String timetable_ed_var = "enable_days";
        public String timetable_sn_var = "start";
        public String timetable_em_var = "end";
        //对象初始化入参
        public String proxy_out_api_url = "";
        public String proxy_out_func_path = "";
        public String proxy_in_func_file = "";
        public String proxy_url_prefix = "";
        public String cmd_string = "";
        public String specified_action_name = "";
        public bool has_end_morning = true;
        public bool get_cmd_result = true;
        public bool is_cmd = false;
        //自动生成参数
        public bool has_timestamp = true;
        public bool has_timetable = true;
        public String action_name = "";
        public String[] tt_names;
        public JsonWriter json_writer;
        public ArrayList py_params;
        private String ExtractActionParams()
        {
            String action_name;
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
                action_name = JsonWriter.ParseCamel(camel_string: action_name);
            }
            return action_name;
        }
        public CodeGen(String json_string)
        {
            this.proxy_out_api_url = "homewlan/sta/setStaRemark2";
            this.proxy_out_func_path = "utils.api.app_v2.functions.frontpage.set_alias";
            this.proxy_in_func_file = "frontpage";
            this.proxy_url_prefix = "functions/v2/frontpage/";
            this.specified_action_name = "";
            this.has_end_morning = true;
            this.is_cmd = true;
            this.cmd_string = "ac_config set -m timeReboot '{}'";
            this.get_cmd_result = true;
            this.get_cmd_result = this.get_cmd_result && this.is_cmd;
            String p_dict_name = "";
            if (this.is_cmd)
            {
                p_dict_name = this.cmd_inner_dict_var;
            }
            else
            {
                p_dict_name = this.plain_req_dict_var;
            }
            this.action_name = this.ExtractActionParams();
            if (this.has_end_morning)
            {
                this.tt_names = new string[] { this.timetable_var, this.timetable_ed_var, this.timetable_sn_var, this.timetable_em_var };
            }
            else
            {
                this.tt_names = new string[] { this.timetable_var, this.timetable_ed_var, this.timetable_sn_var };
            }
            this.json_writer = new JsonWriter(json_string: json_string, p_dict_name: p_dict_name, tt_names: this.tt_names, ts_name: this.timestamp_var);
            this.has_timetable = this.json_writer.has_timetable;
            this.has_timestamp = this.json_writer.has_timestamp;
            this.py_params = new ArrayList();
        }
        public String ProxyOut_write()
        {
            StringWriter sw = new StringWriter();
            sw.WriteLine("# 此标记表明该代码由TOOL生成");
            ArrayList input_params = (ArrayList)this.json_writer.params_list.Clone();
            if (this.is_cmd)
            {
                if (!input_params.Contains("project_id"))
                {
                    input_params.Add(value: "project_id");
                }
                if (!input_params.Contains("sn"))
                {
                    input_params.Add(value: "sn");
                }
            }
            this.py_params = input_params;
            String input_params_string = String.Join(", ", input_params.ToArray());
            sw.WriteLine($"def {this.proxy_out_func_prefix}{this.action_name}({input_params_string}):");
            sw.WriteLine($"    api_name = \"{this.proxy_in_func_prefix}{this.action_name}\"");
            if (this.has_timestamp)
            {
                sw.WriteLine($"    {this.timestamp_var} = str(int(time.time()))");
            }
            if (this.has_timetable)
            {
                if (this.has_end_morning)
                {
                    sw.WriteLine($"    {this.timetable_var} = compose_time_dict(e_days={this.timetable_ed_var}, sn={this.timetable_sn_var}, em={this.timetable_em_var})");
                }
                else
                {
                    sw.WriteLine($"    {this.timetable_var} = compose_time_dict(e_days={this.timetable_ed_var}, sn={this.timetable_sn_var})");
                }
            }
            if (this.is_cmd)
            {
                if (this.cmd_string.EndsWith(value: "'{}'"))
                {
                    foreach (String line in this.json_writer.converted_params)
                    {
                        sw.WriteLine("    " + line);
                    }
                    sw.WriteLine($"    cmd_str = json.dumps(obj={this.cmd_inner_dict_var})");
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
                foreach (String line in this.json_writer.converted_params)
                {
                    sw.WriteLine("    " + line);
                }
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
            StringWriter sw = new StringWriter();
            sw.WriteLine($"from {this.proxy_out_func_path} import {this.proxy_out_func_prefix}{this.action_name}");
            sw.WriteLine("# 此标记表明该代码由TOOL生成");
            sw.WriteLine($"def {this.proxy_in_func_prefix}{this.action_name}(request):");
            sw.WriteLine("    if request.method != \"POST\":");
            sw.WriteLine("        return HttpResponse(status=501)");
            sw.WriteLine("    req_body = json.loads(request.body)");
            for (int index = 0; index < this.py_params.Count; index++)
            {
                sw.WriteLine($"    {this.py_params[index]} = req_body[\"{this.py_params[index]}\"]");
            }
            sw.WriteLine($"    res = {this.proxy_out_func_prefix}{this.action_name}(");
            for (int index = 0; index < this.py_params.Count; index++)
            {
                sw.WriteLine($"        {this.py_params[index]}={this.py_params[index]},");
            }
            sw.WriteLine("    )");
            sw.WriteLine("    return response(res)");
            return sw.ToString();
        }
        public String ProxyUrl_write()
        {
            StringWriter sw = new StringWriter();
            sw.WriteLine($"from . import {this.proxy_in_func_file}");
            sw.WriteLine("# 此标记表明该代码由TOOL生成");
            sw.WriteLine($"urlpatterns.append(path(\"{this.proxy_url_prefix}{this.action_name}\", {this.proxy_in_func_file}.{this.proxy_in_func_prefix}{this.action_name}))");
            return sw.ToString();
        }
        public String RFKeyword_write()
        {
            StringWriter sw = new StringWriter();
            sw.WriteLine("# 此标记表明该代码由TOOL生成");
            String input_params_string = String.Join(", ", this.py_params.ToArray());
            sw.WriteLine($"def {this.rfkw_prefix}{this.action_name}({input_params_string}):");
            sw.WriteLine("    data = {");
            for (int index = 0; index < this.py_params.Count; index++)
            {
                if (index == this.py_params.Count - 1)
                {
                    sw.WriteLine($"        \"{this.py_params[index]}\": {this.py_params[index]}");
                }
                else
                {
                    sw.WriteLine($"        \"{this.py_params[index]}\": {this.py_params[index]},");
                }
            }
            sw.WriteLine("    }");
            sw.WriteLine($"    req = requests.post(TEST_SERVER + \"/api/{this.proxy_url_prefix}{this.action_name}\", data=json.dumps(data))");
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
        public String[] converted_params;
        public ArrayList params_list;
        public static String ParseCamel(String camel_string)
        {
            String underscoreLowercase = Regex.Replace(camel_string, @"([A-Z])", "_$1").ToLower();
            return underscoreLowercase;
        }
        public JsonWriter(String json_string, String p_dict_name, String[] tt_names, String ts_name)
        {
            this.params_list = new ArrayList();
            this.p_dict_name = p_dict_name;
            this.has_timestamp = json_string.Contains(value: "\"#TS\"");
            this.has_timetable = json_string.Contains(value: "\"#TD\"");
            this.converted_params = json_string.Split(separator: "\r\n".ToCharArray(), options: StringSplitOptions.RemoveEmptyEntries);
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
                        case "#VAR_COM":
                            key = JsonWriter.ParseCamel(key);
                            if (!this.params_list.Contains(key))
                            {
                                this.params_list.Add(key);
                            }
                            this.converted_params[i] = this.converted_params[i].Replace("\"#VAR_COM\"", key);
                            break;
                        case "#VAR_UNI":
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
                            this.converted_params[i] = this.converted_params[i].Replace("\"#VAR_UNI\"", key);
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
