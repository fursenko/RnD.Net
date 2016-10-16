
namespace RnD.Net.AppDomain.Monitoring
{
    using System;
    internal sealed class AppDomainMonitorManager: IDisposable
    {
        AppDomain domain;
        TimeSpan domainCpu;
        long domainMemoryInUse;
        long domainMemoryAllocated;
        static AppDomainMonitorManager()
        {
            AppDomain.MonitoringIsEnabled = true;
        }

        public AppDomainMonitorManager(AppDomain dm)
        {
            this.domain = dm ?? AppDomain.CurrentDomain;
            this.domainCpu = this.domain.MonitoringTotalProcessorTime;
            this.domainMemoryInUse = this.domain.MonitoringSurvivedMemorySize;
            this.domainMemoryAllocated = this.domain.MonitoringTotalAllocatedMemorySize;
        }

        public void Dispose()
        {
            GC.Collect();
            var processorTimeDelta = (this.domain.MonitoringTotalProcessorTime - this.domainCpu).TotalMilliseconds;
            Console.WriteLine("Domain: '{0}', CPU usage: {1} ms", this.domain.FriendlyName, processorTimeDelta);
            var totalAllocatedMemory = this.domain.MonitoringTotalAllocatedMemorySize - this.domainMemoryAllocated;
            var survivedMemory = this.domain.MonitoringSurvivedMemorySize - this.domainMemoryInUse;
            Console.WriteLine("Allocated memory: {0} bytes", totalAllocatedMemory);
            Console.WriteLine("Survived memory: {0}", survivedMemory);
        }
    }
}
