using SqlSugar;
using CRM.Common.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddHttpContextAccessor();

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));


#region JWT����

var key = Encoding.ASCII.GetBytes(TokenHelper._jwtSettings.SecretKey ?? "");

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
    option.RequireHttpsMetadata = false;
    option.SaveToken = true;
    option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});


#endregion

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";//ȫ�ִ��� ����ʱ���ʽ
    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;//ȫ�ִ��� ����ʱ�䲢�����ػ�����
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();//����ĸСд�շ�ʽ����
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;//����ѭ������
});
//.AddJsonOptions(options =>
//{
//    //options.JsonSerializerOptions.PropertyNamingPolicy = null;//�����˴���ǰ��ȫ��д
//    options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);//�����˷����������ı�����
//    options.JsonSerializerOptions.Converters.Add(new DatetimeJsonConverter("yyyy-MM-dd HH:mm:ss"));//��ʽ������ʱ���ʽ
//});

#region SqlSugar

services.AddSingleton<ISqlSugarClient>(s =>
{
    SqlSugarScope sqlSugar = new SqlSugarScope(new ConnectionConfig()
    {
        DbType = SqlSugar.DbType.MySql,
        ConnectionString = builder.Configuration.GetConnectionString("crm"),
        IsAutoCloseConnection = true,
    },
   db =>
   {

   });
    return sqlSugar;
});

#endregion

services.InjectionAllServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("corsapp");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();


///// <summary>
///// ��ʽ�����ص�ʱ���ʽ
///// </summary>
//public class DatetimeJsonConverter : JsonConverter<DateTime>
//{
//    private readonly string format;
//    public DatetimeJsonConverter(string _format)
//    {
//        format = _format;
//    }
//    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
//    {
//        var jsonStr = reader.GetString();
//        if (string.IsNullOrEmpty(jsonStr))
//        {
//            return DateTime.MinValue;
//        }

//        if (reader.TokenType == JsonTokenType.String)
//        {
//            if (DateTime.TryParse(reader.GetString(), out DateTime date))
//                return date;
//        }
//        return reader.GetDateTime();
//    }

//    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
//    {
//        writer.WriteStringValue(value.ToString(format));
//    }
//}