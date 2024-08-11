using System.Threading.Tasks;

namespace desktop.Services.Commands
{
    public abstract class Command
    {
        public abstract Task ExecuteAsync();
    }
}
