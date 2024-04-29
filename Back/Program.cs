using System.Text;
using Back.Data;
using ExcelDataReader;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

void MoveFile(string file){
    if (!Directory.Exists("processado")){
        Directory.CreateDirectory("processado");
    }
    string currentDate = DateTime.Now.ToString("yyyyMMddHHmmss");
    string fileExtension = Path.GetExtension(file);
    string newFileName = "processado" + Path.DirectorySeparatorChar + Path.ChangeExtension(Path.GetFileName(file), null) + "_" + currentDate + fileExtension;
    try
        {
            // Mover o arquivo para o novo nome
            File.Move(file, newFileName);
            Console.WriteLine("Arquivo movido com sucesso para: " + newFileName);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao mover o arquivo: " + ex.Message);
        }
}

string? folder = null;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appSettings.json")
    .Build();

folder = configuration["folder"];

if (folder == null)
{
    Console.WriteLine("Informe o caminho para a pasta de entrada: ");
    folder = Console.ReadLine();
    if (folder == null || folder == "")
    {
        Console.WriteLine("Caminho Inválido...");
        Console.WriteLine("Encerrando...");
        Environment.Exit(1);
    }
}

string[] excelFiles = Directory.GetFiles(folder, "*.xlsx");
if (excelFiles.Length == 0)
{
    Console.WriteLine("Nenhum Arquivo presente");
    Console.WriteLine("Encerrando...");
    Environment.Exit(0);
}
var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
using (var dbContext = new AppDbContext(optionsBuilder.Options, configuration))
{
    dbContext.DeleteAllMultistore();
    foreach (string excelFile in excelFiles)
    {
        using (var stream = File.Open(excelFile, FileMode.Open, FileAccess.Read))
        {
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                reader.Read();
                while (reader.Read())
                {
                    var MultiStore = new MultiStore();
                    MultiStore.id = reader.GetDouble(0);
                    MultiStore.order_id = reader.GetString(1);

                    var date = reader.GetDouble(2);
                    MultiStore.order_date = DateOnly.FromDateTime(DateTime.FromOADate(date));
                    date = reader.GetDouble(3);
                    MultiStore.ship_date = DateOnly.FromDateTime(DateTime.FromOADate(date));

                    MultiStore.ship_mode = reader.GetString(4);
                    MultiStore.customer_id = reader.GetString(5);
                    MultiStore.customer_name = reader.GetString(6);
                    MultiStore.customer_age = reader.GetDouble(7);
                    MultiStore.customer_birthday = reader.GetString(8);

                    var activate = reader.GetString(9);
                    if (activate == "Active")
                        MultiStore.customer_state = true;
                    else
                        MultiStore.customer_state = false;

                    MultiStore.segment = reader.GetString(10);
                    MultiStore.country = reader.GetString(11);
                    MultiStore.city = reader.GetString(12);
                    MultiStore.state = reader.GetString(13);
                    MultiStore.regional_manager_id = reader.GetString(14);
                    MultiStore.regional_manager = reader.GetString(15);
                    MultiStore.postal_code = reader.GetValue(16).ToString();
                    MultiStore.region = reader.GetString(17);
                    MultiStore.product_id = reader.GetString(18);
                    MultiStore.category = reader.GetString(19);
                    MultiStore.sub_category = reader.GetString(20);
                    MultiStore.product_name = reader.GetString(21);
                    MultiStore.sales = reader.GetDouble(22);
                    MultiStore.quantity = reader.GetDouble(23);
                    MultiStore.discount = reader.GetDouble(24);
                    MultiStore.profit = reader.GetDouble(25);
                    await dbContext.AddAsync(MultiStore);
                    await dbContext.SaveChangesAsync();
                }
            }
        }
        MoveFile(excelFile);
    }
}

Console.WriteLine("Base importada com sucesso");