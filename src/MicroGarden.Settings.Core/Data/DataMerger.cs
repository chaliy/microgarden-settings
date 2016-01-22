using Newtonsoft.Json.Linq;

namespace MicroGarden.Settings.Core.Data
{
    public static class DataMerger
    {
        public static dynamic Merge(dynamic target, dynamic source)
        {
            var targetJson = JObject.FromObject(target ?? new { });
            var sourceJson = JObject.FromObject(source ?? new { });

            targetJson.Merge(sourceJson, new JsonMergeSettings
            {
                MergeArrayHandling = MergeArrayHandling.Replace
            });

            return targetJson;
        }
    }
}
