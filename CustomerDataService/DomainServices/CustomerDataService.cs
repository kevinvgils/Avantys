using CustomerDataService.Domain.Events;
using MassTransit;
using EventLibrary;


namespace CustomerDataService.DomainServices
{
    public class CustomerDataService: Interfaces.ICustomerService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IPublishEndpoint _publishEndpoint;

        public CustomerDataService(IHttpClientFactory httpClientFactory, IPublishEndpoint publishEndpoint)
        {
            _httpClientFactory = httpClientFactory;
            _publishEndpoint = publishEndpoint;
            
        }
        public async Task GetCustomers()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://marcavans.blob.core.windows.net/solarch/fake_customer_data_export.csv?sv=2023-01-03&st=2024-06-14T10%3A31%3A07Z&se=2032-06-15T10%3A31%3A00Z&sr=b&sp=r&sig=q4Ie3kKpguMakW6sbcKl0KAWutzpMi747O4yIr8lQLI%3D");
            if (response.IsSuccessStatusCode)
            {
                var csvData = await response.Content.ReadAsStringAsync();
                var customers = csvData.Split('\n').Skip(1).Select(line => line.Split(','));
                foreach (var customer in customers)
                {
                    var name = $"{customer[1]} {customer[2]}";
                    var email = $"{name.Replace(" ", "").ToLower()}@avantys.com";
                    var customerFetched = new ApplicantCreated()
                    {
                        ApplicantId = Guid.NewGuid(),
                        Name = name,
                        Email = email,
                        StudyProgram = ""
                    };
                    await _publishEndpoint.Publish(customerFetched, context =>
                    {
                        context.SetRoutingKey("applicant.created");
                    });
                }
                
              
            }
            
        }
    }
}
