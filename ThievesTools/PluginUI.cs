using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using VoK.Sdk.Ddo;
using VoK.Sdk.Plugins;

namespace ThievesTools {
    public class PluginUI : IPluginUI {

        private IDdoGameDataProvider _provider;
        private InGameUI _igui;
        private String _folder;

        public PluginUI(IDdoGameDataProvider provider, string folder) {
            _provider = provider;
            _igui = new InGameUI(provider, folder);
            _folder = folder;
        }

        public float? FocusedOpacity => 1.0f;

        public bool EnabledInCharacterSelection => false;

        public Image ToolbarImage => Properties.Resources.tools;

        public object UserInterfaceForm => _igui;

        public Tuple<int, int> MinSize => new(400, 200);

        public void Terminate() {
            // Cleanup
        }

    }
}
