using MassTransit;
using ProgressService.Domain;
using ProgressService.DomainServices.Interfaces;
using EventLibrary;

namespace ProgressService.Consumer.TestConsumers
{
    public class TestUpdatedConsumer : IConsumer<TestUpdated>
    {
        private readonly ITestRepository _TestRepository;
        private readonly IProgressService _progressService;

        public TestUpdatedConsumer(IProgressService progressService, ITestRepository testRepository)
        {
            _progressService = progressService;
            _TestRepository = testRepository;
        }
        public async Task Consume(ConsumeContext<TestUpdated> context)
        {
            // Log the received message
            Console.WriteLine($"Received TestUpdated Event: Message={context.Message}");

            // Create a new Test instance from the consumed message
            TestUpdated test = new TestUpdated(context.Message.Id, context.Message.Module);

            try
            {
                // Save the test using the repository
                Test returnedTest = await _TestRepository.UpdateTest(test);
                await _progressService.DeleteProgressAsync(new Test(returnedTest.Id, returnedTest.Module));

                // Log the consumed event
                Console.WriteLine($"CONSUMED TestUpdated Event: Id={returnedTest.Id}, Module={returnedTest.Module}");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during processing
                Console.WriteLine($"Error processing TestUpdated Event: {ex.Message}");
                // Optionally, throw the exception or handle it accordingly
                throw;
            }
        }
    }
}
