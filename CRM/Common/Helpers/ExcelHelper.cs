using CRM.Common;
using CRM.Common.Helpers;
using Dm;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.ComponentModel;
using System.Data;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace CRM.Commons.Helpers
{
    /// <summary>
    /// Excel帮助类
    /// </summary>
    public class ExcelHelper
    {
        ///// <summary>
        ///// 导出Excel
        ///// </summary>
        ///// <param name="data">数据</param>
        ///// <param name="filePath">文件名路径</param>
        ///// <param name="otherData">其他数据</param>
        //public static string GetExportPath<T>(List<T> data, string filePath, DataTable? otherData = null)
        //{
        //    ExcelPackage.LicenseContext = LicenseContext.Commercial;
        //    using (var excel = new ExcelPackage())
        //    {
        //        ExcelWorksheet ws = excel.Workbook.Worksheets.Add("sheet");
        //        ws.Cells["A1"].LoadFromCollection(data, true);
        //        SetExcelStyle(ws);

        //        if (otherData != null)
        //        {
        //            ExcelWorksheet ws2 = excel.Workbook.Worksheets.Add("sheet2");
        //            ws2.Cells["A1"].LoadFromDataTable(otherData, true);
        //            SetExcelStyle(ws2);
        //        }

        //        var bytes = excel.GetAsByteArray();
        //        var path = UploadHelper.UploadFile(bytes, filePath);
        //        return path;
        //    }
        //}

        ///// <summary>
        ///// 导出Excel
        ///// </summary>
        ///// <param name="data">数据</param>
        ///// <param name="filePath">文件路径</param>
        //public static string GetExportPath(DataTable data, string filePath)
        //{
        //    ExcelPackage.LicenseContext = LicenseContext.Commercial;
        //    using (var excel = new ExcelPackage())
        //    {
        //        ExcelWorksheet ws = excel.Workbook.Worksheets.Add("sheet");
        //        ws.Cells["A1"].LoadFromDataTable(data, true);
        //        SetExcelStyle(ws);
        //        var bytes = excel.GetAsByteArray();
        //        var path = UploadHelper.UploadFile(bytes, filePath);
        //        return path;
        //    }
        //}

        ///// <summary>
        ///// 导出Excel（自定义格式与样式）
        ///// </summary>
        ///// <param name="data">数据</param>
        ///// <param name="filePath">文件路径</param>
        //public static string GetExportPath(List<GetExcelModel> data, string filePath)
        //{
        //    ExcelPackage.LicenseContext = LicenseContext.Commercial;
        //    using (var excel = new ExcelPackage())
        //    {
        //        foreach (var sheet in data)
        //        {
        //            ExcelWorksheet ws2 = excel.Workbook.Worksheets.Add(sheet.SheetName);
        //            ws2.Cells["A1"].LoadFromDataTable(sheet.Data, true);
        //            sheet.SetExcelStyleFun(ws2);
        //            sheet.Operation?.Invoke(ws2);
        //        }

        //        var bytes = excel.GetAsByteArray();
        //        var path = UploadHelper.UploadFile(bytes, filePath);
        //        return path;
        //    }
        //}

        /// <summary>
        /// 设置样式
        /// </summary>
        /// <param name="ws"></param>
        public static void SetExcelStyle(ExcelWorksheet ws)
        {
            var row = ws.Dimension.Rows;
            var column = ws.Dimension.Columns;

            //冻结首行
            ws.View.FreezePanes(2, 1);

            //设置单元格所有边框
            ws.Cells[1, 1, row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            ws.Cells[1, 1, row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            ws.Cells[1, 1, row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            ws.Cells[1, 1, row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            //字体
            ws.Cells[1, 1, row, column].Style.Font.Name = "微软雅黑";
            //水平居中
            //ws.Cells[1, 1, row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[1, 1, row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            //自适应大小
            //ws.Cells[1, 1, row, column].Style.ShrinkToFit = true;

            //首行字体为粗体
            ws.Cells[1, 1, 1, column].Style.Font.Bold = true;
            //首行背景色
            ws.Cells[1, 1, 1, column].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[1, 1, 1, column].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(192, 234, 182));
            //设置列宽
            for (var i = 1; i <= column; i++)
            {
                ws.Column(i).Width = 20;
            }
        }

        /// <summary>
        /// 读取Excel
        /// </summary>
        /// <param name="uploadFiles">上传的文件</param>
        /// <returns></returns>
        public static ReadExcelModel<T> ReadExcel<T>(IFormFileCollection uploadFiles) where T : new()
        {
            var result = new ReadExcelModel<T>();
            try
            {
                //判断是否上传了文件
                if (uploadFiles == null || uploadFiles.Count == 0 || uploadFiles[0] == null)
                {
                    result.Message = "请上传一个Excel文件";
                    return result;
                }
                var file = uploadFiles[0];
                //获取文件类型
                string fileExtension = Path.GetExtension(file.FileName);
                //判断文件类型是否正确
                if (fileExtension == null || !"xlsx".Equals(fileExtension.ToLower().Replace(".", "")))
                {
                    result.Message = "请上传.xlsx格式的文件";
                    return result;
                }
                //获取文件大小
                var fileLength = file.Length;
                ////判断文件大小是否符合
                //if (fileLength > 10 * 1020 * 1024)
                //{
                //    result.Message = "The file size is not allowed to exceed 10M";
                //    return result;
                //}
                //读取Excel返回对应实体
                using (Stream stream = file.OpenReadStream())
                {
                    result.ResultData = ReadExcel<T>(stream);
                    result.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                //LoggerHelper.Error(LogEnum.Common, "ReadExcel error:" + ex);
                result.Message = "ReadExcel error！";
            }
            return result;
        }

        /// <summary>
        /// 读取Excel获取数据
        /// </summary>
        /// <typeparam name="T">返回的数据集（属性名需要定义成string类型）</typeparam>
        /// <param name="inputStrem">Excel文件流</param>
        /// <returns></returns>
        public static List<T> ReadExcel<T>(Stream inputStrem) where T : new()
        {
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            using (var excel = new ExcelPackage(inputStrem))
            {
                ExcelWorksheet ws = excel.Workbook.Worksheets[0];
                int rowCount = ws.Dimension.Rows;
                //定义返回集合
                List<T> result = new List<T>();
                for (int i = 2; i <= rowCount; i++)
                {
                    T info = new T();
                    Type objType = info.GetType();
                    //获取对象参数数量
                    var propertiesCount = objType.GetProperties().Length;
                    //循环给参数赋值
                    var properties = objType.GetProperties();
                    for (int k = 0; k < propertiesCount; k++)
                    {
                        var value = ws.Cells[i, k + 1]?.Value?.ToString()?.Trim();
                        if (ws.Cells[i, k + 1].Style.Numberformat.Format.Contains("yy"))
                        {
                            value = ws.Cells[i, k + 1]?.Text.ToDateTime()?.ToString("yyyy-MM-dd HH:mm") ?? value;
                        }
                        properties[k].SetValue(info, value ?? string.Empty);
                    }
                    result.Add(info);
                }
                return result;
            }
        }

        /// <summary>
        /// 读取excel行
        /// </summary>
        /// <param name="inputStrem"></param>
        /// <returns></returns>
        public static List<string>? ReadExcelLines(Stream inputStrem)
        {
            List<string> lines = new List<string>();
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                using (ExcelPackage package = new ExcelPackage(inputStrem))
                {
                    ExcelWorksheet sheet = package.Workbook.Worksheets[0];
                    if (sheet == null)
                    {
                        return null;
                    }
                    int rowCount = sheet.Dimension.End.Row;
                    int colCount = sheet.Dimension.End.Column;

                    for (var i = 1; i <= rowCount; i++)
                    {
                        var line = string.Empty;
                        for (var j = 1; j <= colCount; j++)
                        {
                            var value = sheet.Cells[i, j].Text?.ToString() ?? "Empty";
                            if (sheet.Cells[i, j].Style.Numberformat.Format.Contains("yy"))
                            {
                                value = value.ToDateTime()?.ToString("yyyy-MM-dd HH:mm") ?? value;
                            }
                            line += value.Trim() + (j != colCount ? "\t" : string.Empty);
                        }
                        lines.Add(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Read Task From Excel Error" + ex); ;
            }

            return lines;
        }

        #region 实体

        /// <summary>
        /// 读取Excel返回实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class ReadExcelModel<T> where T : new()
        {
            /// <summary>
            /// 是否成功
            /// </summary>
            public bool IsSuccess { get; set; }

            /// <summary>
            /// 信息
            /// </summary>
            public string Message { get; set; } = string.Empty;

            /// <summary>
            /// 返回数据
            /// </summary>
            public List<T> ResultData { get; set; } = new List<T>();
        }
        #endregion
    }

    /// <summary>
    /// 获取excel实体
    /// </summary>
    public class GetExcelModel
    {
        /// <summary>
        /// sheet名
        /// </summary>
        public string SheetName { get; set; } = "Sheet1";

        /// <summary>
        /// 数据
        /// </summary>
        public DataTable? Data { get; set; }

        /// <summary>
        /// 样式方法委托
        /// </summary>
        public Action<ExcelWorksheet> SetExcelStyleFun { get; set; } = ExcelHelper.SetExcelStyle;

        /// <summary>
        /// excel操作方法委托
        /// </summary>
        public Action<ExcelWorksheet>? Operation { get; set; }
    }

}
