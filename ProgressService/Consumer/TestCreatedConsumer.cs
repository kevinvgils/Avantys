using MassTransit;
using ProgressService.Domain;
using ProgressService.DomainServices.Interfaces;
using EventLibrary;

namespace ProgressService.Consumer
{
    public class TestCreatedConsumer : IConsumer<TestCreated>
    {
        private readonly ITestRepository _TestRepository;
        private readonly IProgressService _progressService;

        public TestCreatedConsumer(IProgressService progressService, ITestRepository testRepository)
        {
            _progressService = progressService;
            _TestRepository = testRepository;
        }
        public async Task Consume(ConsumeContext<TestCreated> context)
        {
            // Log the received message
            Console.WriteLine($"Received TestCreated Event: Message={context.Message}");

            // Create a new Test instance from the consumed message
            TestCreated test = new TestCreated(context.Message.Id, context.Message.Module);

            try
            {
                // Save the test using the repository
                TestCreated returnedTest = await _TestRepository.CreateTest(test);

                // Create progress for the test
                await _progressService.CreateProgressAsync(test);

                // Log the consumed event
                Console.WriteLine($"CONSUMED TestCreated Event: Id={returnedTest.Id}, Module={returnedTest.Module}");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during processing
                Console.WriteLine($"Error processing TestCreated Event: {ex.Message}");
                // Optionally, throw the exception or handle it accordingly
                throw;
            }
        }
    }
}
