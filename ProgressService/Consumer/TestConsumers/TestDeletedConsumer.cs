using MassTransit;
using ProgressService.Domain;
using ProgressService.DomainServices.Interfaces;
using EventLibrary;

namespace ProgressService.Consumer.TestConsumers
{
    public class TestDeletedConsumer : IConsumer<TestDeleted>
    {
        private readonly ITestRepository _TestRepository;
        private readonly IProgressService _progressService;

        public TestDeletedConsumer(IProgressService progressService, ITestRepository testRepository)
        {
            _progressService = progressService;
            _TestRepository = testRepository;
        }
        public async Task Consume(ConsumeContext<TestDeleted> context)
        {
            // Log the received message
            Console.WriteLine($"Received TestDeleted Event: Message={context.Message}");

            // Create a new Test instance from the consumed message
            TestDeleted test = new TestDeleted(context.Message.Id);

            try
            {
                // Save the test using the repository
                Test returnedTest = await _TestRepository.DeleteTest(test);
                await _progressService.DeleteProgressAsync(new Test(returnedTest.Id, null));

                // Log the consumed event
                Console.WriteLine($"CONSUMED TestDeleted Event: Id={returnedTest.Id}");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during processing
                Console.WriteLine($"Error processing TestDeleted Event: {ex.Message}");
                // Optionally, throw the exception or handle it accordingly
                throw;
            }
        }
    }
}
