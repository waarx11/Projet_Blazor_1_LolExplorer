using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace LolExplorer.Shared
{
    public partial class Footer
    {


        [Inject]
        public IConfiguration Configuration { get; set; }

        [Inject]
        public IOptions<PositionOptions> OptionsPositionOptions { get; set; }

        private PositionOptions positionOptions;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            positionOptions = OptionsPositionOptions.Value;
        }

    }
}
