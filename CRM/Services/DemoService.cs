using CRM.Repositories;
using SqlSugar;
using CRM.Common.Helpers;
using CRM.Services.Interfaces;
using System.Reflection;

namespace CRM.Services
{
    public class DemoService : IDemoService
    {
        private ISqlSugarClient _sqlSugarClient;
        private readonly string ModelNameTemp = "$ModelName$";
        private readonly string ModelTemp = "$Model$";
        public DemoService(ISqlSugarClient db) 
        {
            _sqlSugarClient = db;
        }

        public void CreateModelFiles()
        {
            var tables = _sqlSugarClient.DbMaintenance.GetTableInfoList(false);
         
            _sqlSugarClient.DbFirst.IsCreateAttribute()
                .FormatClassName(it => it.UnderscoreToPascalCase() + "Model")
                .FormatFileName(it => it.UnderscoreToPascalCase() + "Model")
                .FormatPropertyName(it => it.UnderscoreToPascalCase())
                .CreateClassFile(Path.Combine(Directory.GetCurrentDirectory(), "Models/DB"));
        }

        public void CreateCodeFiles()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var allTypes = assemblies.SelectMany(assembly => assembly.GetTypes()).Where(a => a.GetCustomAttribute(typeof(SugarTable)) != null);
            foreach (var type in allTypes)
            {
                string modelName = type.Name.Replace("Model", "");
                string model = type.Name;

                CreateRepositoryFiles(modelName, model);
                CreateIServiceFiles(modelName);
                CreateServiceFiles(modelName);
                CreateControllerFiles(modelName);
            }
        }

        private void CreateIServiceFiles(string modelName)
        {
            string fileName = $"I{modelName}Service.cs";
            string fileFullName = $"./Services/Interfaces/{fileName}";
            string templateFilePath = @".\Templates\Code\IServiceTemplate.txt";
            CreateFiles(fileFullName, modelName, templateFilePath);
        }

        private void CreateServiceFiles(string modelName)
        {
            string fileName = $"{modelName}Service.cs";
            string fileFullName = $"./Services/{fileName}";
            string templateFilePath = @".\Templates\Code\ServiceTemplate.txt";
            CreateFiles(fileFullName, modelName, templateFilePath);
        }

        private void CreateControllerFiles(string modelName)
        {
            string fileName = $"{modelName}Controller.cs";
            string fileFullName = $"./Controllers/{fileName}";
            string templateFilePath = @".\Templates\Code\ControllerTemplate.txt";
            CreateFiles(fileFullName, modelName, templateFilePath);
        }

        private void CreateRepositoryFiles(string modelName, string model)
        {
            string fileName = $"{modelName}Repository.cs";
            string fileFullName = $"./Repositories/{fileName}";
            string templateFilePath = @".\Templates\Code\RepositoryTemplate.txt";
            CreateFiles(fileFullName, modelName, templateFilePath, model);
        }

        private void CreateFiles(string fileFullName, string modelName,string templateFilePath, string model = "")
        {
            string template = File.ReadAllText(templateFilePath);
            string fileContent = template.Replace(ModelNameTemp, modelName);
            if(model != "")
            {
                fileContent = fileContent.Replace(ModelTemp, model);
            }

            File.WriteAllText(fileFullName, fileContent);
        }
    }
}
