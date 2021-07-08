using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SSDCPortal.Theme.Material.Demo.Shared.Common
{
    public class SampleListType
    {
        public List<SampleListType> SourceData { get; set; }
        public string Name { get; set; }
        [Newtonsoft.Json.JsonConverter(typeof(JsonConverter))]
        public SampleType Type { get; set; }
        public List<Sample> Samples { get; set; }
        public string DemoPath { get; set; }
        public string Category { get; set; }
    }

    public class SampleList
    {
        public string Name { get; set; }
        public string Directory { get; set; }
        public string Category { get; set; }
        [Newtonsoft.Json.JsonConverter(typeof(JsonStringEnumConverter))]
        public SampleType Type { get; set; }
        public List<Sample> Samples { get; set; } = new List<Sample>();
        public string ControllerName { get; set; }
        public string DemoPath { get; set; }
        public bool IsPreview { get; set; }
        public string CustomDocLink { get; set; }
    }

    public class Sample
    {
        public string Name { get; set; }
        public string Directory { get; set; }
        public string Category { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
        public string MappingSampleName { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string HeaderText { get; set; }
        public List<SourceCollection> SourceFiles { get; set; } = new List<SourceCollection>();
        [Newtonsoft.Json.JsonConverter(typeof(JsonStringEnumConverter))]
        public SampleType Type { get; set; }
    }

    public class SourceCollection
    {
        public string FileName { get; set; }
        public string Id { get; set; }
    }

    internal static class SampleBrowser
    {
        public static List<SampleList> SampleList { get; set; } = new List<SampleList>();
        internal static List<string> SampleUrls = new List<string>();
        internal static SampleConfig Config { get; set; } = new SampleConfig();
        internal static List<string> PreLoadFiles = new List<string>()
        {
            "styles/common/fonts/open-sans-700.woff2",
            "styles/common/fonts/open-sans-regular.woff2",
        };
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SampleType
    {
        // [EnumMember(Value = "none")]
        None,
        //  [EnumMember(Value = "new")]
        New,
        //    [EnumMember(Value = "updated")]
        Updated,
        //   [EnumMember(Value = "preview")]
        Preview
    }
}
