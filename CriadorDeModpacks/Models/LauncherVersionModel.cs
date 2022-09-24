using System.Text.Json.Serialization;

namespace CriadorDeModpacks.Models
{

    public class LauncherVersionModel
    {
        public class Linux64Model
        {
            [JsonPropertyName("url")]
            public string Url { get; set; }
            public Linux64Model(string url)
            {
                Url = url;
            }
            public Linux64Model()
            {

            }
        }

        public class Mac64Model
        {
            [JsonPropertyName("url")]
            public string Url { get; set; }
            public Mac64Model(string url)
            {
                Url = url;
            }
            public Mac64Model()
            {

            }
        }

        public class Win64Model
        {
            [JsonPropertyName("url")]
            public string Url { get; set; }
            public Win64Model(string url)
            {
                Url = url;
            }
            public Win64Model()
            {

            }
        }

        public class PackagesModel
        {
            [JsonPropertyName("win64")]
            public Win64Model Win64 { get; set; }

            [JsonPropertyName("mac64")]
            public Mac64Model Mac64 { get; set; }

            [JsonPropertyName("linux64")]
            public Linux64Model Linux64 { get; set; }
        }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("packages")]
        public PackagesModel Packages { get; set; }

        [JsonIgnore]
        public List<FileUploadModel> Files { get; set; }
    }
    public class FileUploadModel
    {
        public FileStream file { get; set; }
        public string path { get; set; }
        public FileUploadModel(FileStream file, string path)
        {
            this.file = file;
            this.path = path;
        }
    }
}
