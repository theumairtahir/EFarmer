namespace EFarmer.pk.Areas.Admin.Common
{
    public static class RenderedActionButtons
    {
        public static string GetActionButtons(string insightsCallback, string editCallback, string deleteCallback)
        {
            string format = @"<div class=""row"">
                                                <div class=""col-4"">
                                                    <a href = ""#"" onclick = ""{0}"" ><i class=""fas fa-chart-bar text-info"" title=""Insights""></i></a>
                                                </div>
                                                <div class=""col-4"">
                                                    <a href=""#"" onclick=""{1}""><i class=""fas fa-edit text-success"" title=""Edit""></i></a>
                                                </div>
                                                <div class=""col-4"">
                                                    <a href=""#"" onclick=""{2}""><i class=""fas fa-trash text-danger"" title=""Delete""></i></a>
                                                </div>
                                            </div>";
            var result = string.Format(format, insightsCallback, editCallback, deleteCallback);
            return result;
        }
        public static string GetActionButtonsWithBlockIcon(string insightsCallback, string blockCallback)
        {
            string format = @"<div class=""row"">
                                                <div class=""col-6"">
                                                    <a href = ""#"" onclick = ""{0}"" ><i class=""fas fa-chart-bar text-info"" title=""Insights""></i></a>
                                                </div>
                                                <div class=""col-6"">
                                                    <a href=""#"" onclick=""{1}""><i class=""fas fa-ban text-danger"" title=""Block""></i></a>
                                                </div>
                                            </div>";
            var result = string.Format(format, insightsCallback, blockCallback);
            return result;
        }
    }
}
