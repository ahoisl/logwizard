using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lw_common.parse.parsers.file {
    class json_file : file_parser_base {

        private StringBuilder sb_ = new StringBuilder();
        private int open_count_ = 0;

        public json_file(file_text_reader reader) : base(reader) { }

        protected override void on_new_lines(string new_lines) {
            foreach(var c in new_lines.ToCharArray()) {
                sb_.Append(c);

                if(c == '{') {
                    open_count_++;
                } else if(c == '}') {
                    open_count_--;
                    if(open_count_ == 0) {
                        // Full object in buffer
                        var obj = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(sb_.ToString());
                        var line = new log_entry_line();

                        foreach (var entry in obj) {
                            var value = entry.Value.ToString();
                            if (entry.Value.GetType() == typeof(DateTime)) {
                                value = ((DateTime)entry.Value).ToString("o");
                            }
                            line.analyze_and_add(entry.Key, value);
                        }

                        lock (this) {
                            entries_.Add(line);
                            string_.add_preparsed_line(line.ToString());
                        }

                        sb_.Clear();
                    }
                }
            }
        }

    }
}
