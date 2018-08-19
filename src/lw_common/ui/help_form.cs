using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lw_common.ui {
    public partial class help_form : Form {

        private string base_url_ = "https://github.com/habjoc/logwizard/wiki/";
        private string hrefText = "/habjoc/logwizard/wiki";

        private Dictionary<string, string> page_content_ = new Dictionary<string, string>();

        public help_form(bool home = true) {
            InitializeComponent();
            init();
            open_wiki("");
        }

        public help_form(string help_page) : this(false) {
            open_wiki(help_page);
        }

        private void init() {
            var items = get_items();
            foreach(var item in items) {
                helpPicker.Nodes.Add(new TreeNode() {
                    Name = "N" + item.Key,
                    Text = item.Key,
                    Tag = item.Value
                });
            }
        }

        private void helpPicker_AfterSelect(object sender, TreeViewEventArgs e) {
            if(helpPicker.SelectedNode.Tag != null) {
                helpViewer.DocumentText = "0";
                helpViewer.Document.OpenNew(true);
                helpViewer.Document.Write(parse_wiki_page(read_wiki_page(base_url_ + helpPicker.SelectedNode.Tag.ToString())));
                helpViewer.Refresh();
            }
        }

        public void open_wiki(string help_page) {
            var node = get_node(help_page);
            if(node != null) {
                open_wiki(node);
            }
        }

        private void open_wiki(TreeNode node) {
            helpPicker.SelectedNode = node;
        }

        private TreeNode get_node(string help_page) {
            foreach(var node in helpPicker.Nodes) {
                var tn = (TreeNode)node;
                if (tn.Tag != null && tn.Tag.ToString().ToLower() == help_page.ToLower()) return (TreeNode) node;
            }
            return null;
        }

        private Dictionary<string, string> get_items() {
            var dict = new Dictionary<string, string>();
            var lines = read_wiki_page(base_url_).Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines) {
                var iof = line.IndexOf(hrefText);
                if(iof > 0 && line.Contains("<strong>")) {
                    var content = line.Substring(iof + hrefText.Length);
                    if (content[0] == '/') content = content.Substring(1);
                    var split = content.IndexOf("\">");
                    var path = content.Substring(0, split);
                    var name = content.Substring(split + 2, content.IndexOf("</a>") - split - 2);
                    dict.Add(name, path);
                }
            }
            return dict;
        }

        private string read_wiki_page(string url) {
            if(page_content_.TryGetValue(url, out var result)) {
                return result;
            }

            try {
                WebClient client = new WebClient();
                client.Headers.Add("user-agent", 
                    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.113 Safari/537.36");
                Stream data = client.OpenRead(url);
                StreamReader reader = new StreamReader(data);
                string s = reader.ReadToEnd();
                page_content_.Add(url, s);
                return s;
            } catch (Exception) {
                // TODO: Logging
            }
            return "";
        }

        private string parse_wiki_page(string content) {
            var sb = new StringBuilder();
            var lines = content.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            var add = true;
            foreach(var line in lines) {
                var append = add;
                if (line.Contains("<body")) {
                    add = false;
                    append = true;
                } else if (line.Contains("<h1 ")) {
                    append = true;
                } else if (line.Contains("wiki-body")) {
                    add = true;
                    append = true;
                } else if (line.Contains("wiki-footer")) {
                    add = false;
                    append = false;
                } else if (line.Contains("wiki-rightbar")) {
                    add = false;
                    append = false;
                } else if (line.Contains("</body>")) {
                    add = true;
                    append = true;
                } 

                if (append) sb.AppendLine(line);
            }
            return sb.ToString();
        }

        private void helpViewer_Navigating(object sender, WebBrowserNavigatingEventArgs e) {
            string target = e.Url.ToString();

            if (target == "about:blank") {
                // Allow this
            } else if (target.Contains(hrefText)) {
                e.Cancel = true;
                target = target.Substring(target.IndexOf("/wiki") + "/wiki".Length);
                if (target.StartsWith("/")) target = target.Substring(1);
                open_wiki(target);
            } else {
                e.Cancel = true;
            }
        }
    }
}
