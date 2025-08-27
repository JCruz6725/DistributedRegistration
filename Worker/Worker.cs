using System.Net.Http.Json;
using System.Numerics;

namespace Worker {
    public class Worker : BackgroundService {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger) {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken) {

            bool isRegistered = false; 
            Guid guid = Guid.Empty;


            while(!stoppingToken.IsCancellationRequested) {
                

                if(!isRegistered) {
                    _logger.LogInformation("Registering worker at: {time}", DateTimeOffset.Now);

                    //call master to register and get some id
                    using(HttpClient h  = new HttpClient() { BaseAddress = new Uri("http://localhost:5251") }) {
                        guid  = await h.GetFromJsonAsync<Guid>("api/Registration");
                    }
                    
                    isRegistered = true;
                    _logger.LogInformation("Id: {guid}", guid);
                }
                else {

                    // Ask master for work

                    _logger.LogInformation("Id: {guid} \nDoing work!", guid);

                    // Do some work
                    //await Task.Delay(5000, stoppingToken);

                }





                //if(_logger.IsEnabled(LogLevel.Information)) {
                //    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                //}
                await Task.Delay(1000, stoppingToken);
            }
        
            
            
            
        }
    }
}
