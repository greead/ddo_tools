using VoK.Sdk;
using VoK.Sdk.Ddo;
using VoK.Sdk.Plugins;

namespace ThievesTools {
    public class ThievesTools : IDdoPlugin {

        public static ThievesTools Instance;

        public ThievesTools() {
            Instance = this;
        }

        private static Guid _pluginId = Guid.Parse("eb651cbb-afa8-43c3-9e2b-444eea06694c");
        private PluginUI _pui;
        private IGameDataProvider _dataProvider;
        private string _folder;

        public Guid PluginId => _pluginId;

        public GameId Game => GameId.DDO;

        public string PluginKey => "f30ad735-035c-40c6-aaf0-75351c7c7bd2";

        public string Name => "Thieves' Tools";

        public string Description => "QoL tools for your DDO adventures!";

        public string Author => "AG";

        public Version Version => this.GetType().Assembly.GetName().Version;

        public IPluginUI GetPluginUI() {
            return _pui;
        }

        public void Initialize(IDdoGameDataProvider gameDataProvider, string folder) {
            _dataProvider = gameDataProvider;
            _pui = new PluginUI(gameDataProvider, folder);
            _folder = folder;
            Instance = this;
        }

        public void Terminate() {
            _pui.Terminate();
        }
    }
}
