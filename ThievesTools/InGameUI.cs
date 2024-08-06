using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VoK.Sdk;
using VoK.Sdk.Common;
using VoK.Sdk.Dat;
using VoK.Sdk.Ddo;
using VoK.Sdk.Ddo.Enums;
using VoK.Sdk.Enums;
using VoK.Sdk.Helpers;
using VoK.Sdk.Properties;

namespace ThievesTools {
    public partial class InGameUI : Form {

        private IDdoGameDataProvider _provider;
        private String _fplugin;
        private String _fclient;
        private IPropertyMaster _propertyMaster;
        private IDdoEventProvider _eventProvider;
        private IDatFile _clientGeneral;
        private IDatFile _clientGamelogic;
        private IEntity _cchar;

        public InGameUI(IDdoGameDataProvider provider, string folder) {
            // Set up variables
            _provider = provider;
            _eventProvider = provider.EventProvider;
            _fclient = provider.ClientFolder;
            _fplugin = folder;
            _propertyMaster = PropertyMasterFactory.GetPropertyMaster(_fclient);
            _clientGeneral = DatFactory.LoadDatFile(Path.Combine(_provider.ClientFolder, "client_general.dat"));
            _clientGamelogic = DatFactory.LoadDatFile(Path.Combine(_provider.ClientFolder, "client_gamelogic.dat"));
            _cchar = _provider.GetCurrentCharacter();

            InitializeComponent();

            //_eventProvider.OnRunScript.AddHandler((ScriptEventArgs args) => {
            //    lstDebugOut.Items.Add($"({(FX)args.FxId}, {(FX)args.SecondaryFxId}); ({_provider.GetEntity(args.ScriptSourceIid)} => 0x{_provider.GetEntity(args.ScriptTargetIid)}): ");
            //    if (args.Properties != null) {
            //        lstDebugOut.Items.Add($"\t{args.Properties.ToString()}");

            //    } else {
            //        lstDebugOut.Items.Add("NO PROPS");
            //    }
            //    lstDebugOut.TopIndex = lstDebugOut.Items.Count - 1;
            //    return new Task(() => {});
            //}, ThievesTools.Instance);

            _eventProvider.OnUiEvent.AddHandler((IUiEvent args) => {
                lstDebugOut.Items.Add($"{(UIElementID)args.UiElementId} : {args.Event}");
                lstDebugOut.TopIndex = lstDebugOut.Items.Count - 1;
                return new Task(() => { });
            }, ThievesTools.Instance);



        }

    // Button for opening a wiki page to the current quest
    private void btnOpenWiki_Click(object sender, EventArgs e) {

            var active_quest_id = _cchar.GetProperty((uint)DdoProperty.Dungeon_Player_ActiveQuest);

            if (active_quest_id != null) {

                var active_quest_props = _propertyMaster.GetPropertyCollection((uint)active_quest_id.RawUInt32);

                if (active_quest_props != null) {

                    var active_quest_name = active_quest_props.GetStringInfoProperty((uint)DdoProperty.Quest_Name).Text;

                    btnOpenWiki.Text = $"{active_quest_name} (Click to refresh)";
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo {
                        FileName = $"http://www.ddowiki.com/page/{active_quest_name}",
                        UseShellExecute = true
                    });

                }
                else {
                    btnOpenWiki.Text = "Errors getting quest details... (Click to refresh)";
                }
            }
            else {
                btnOpenWiki.Text = "No active quest... (Click to refresh)";
            }
        }



        private void display_all(IPropertyCollection props) {
            
            if (props != null) {
                lstDebugOut.Items.Add(" ");
                lstDebugOut.Items.Add($"{props.Name} PROPERTIES");

                foreach (var prop in props.Properties) {
                    lstDebugOut.Items.Add($"(0x{prop.Value.PropertyId:X8}) {prop.Value.PropertyName}");

                    if (prop.Value.Type == "Int32") {
                        lstDebugOut.Items.Add($"{"(" + prop.Value.Type,15})\t0x{prop.Value.Value:X8}");
                    }
                    else {
                        lstDebugOut.Items.Add($"{"(" + prop.Value.Type,15})\t{prop.Value.Value}");
                    }
                }
            }
        }

        private void btnRunDebug_Click(object sender, EventArgs e) {

            lstDebugOut.Items.Clear();

            

            //var test_id = UIElementID.ChatLog;

            //lstDebugOut.Items.Add("testing: " + test_id.ToString() + ", " + (uint)test_id);

            //var ui_entity = _provider.GetEntity((ulong)test_id);
            //if (ui_entity != null) {
            //    lstDebugOut.Items.Add("entity found: " + ui_entity.ToString());
            //} else {
            //    lstDebugOut.Items.Add("no entity found");
            //}

            //var ui_props = _propertyMaster.GetPropertyCollection((uint)test_id);
            //if (ui_props != null) {
            //    lstDebugOut.Items.Add("props found: " + ui_props.ToString());     
            //    display_all(ui_props);
            //} else {
            //    lstDebugOut.Items.Add("no props found");
            //}

            //var ui_weens = _provider.GetWeenieProperties((uint)test_id);
            //if (ui_weens != null) {
            //    lstDebugOut.Items.Add("weens found: " + ui_weens.ToString());
            //    lstDebugOut.Items.Add("weens found: " + ui_weens.ToString());
            //} else {
            //    lstDebugOut.Items.Add("no weens found");
            //}

            //var ui_loc = _provider.GetUiElementLocation((uint)test_id);
            //if (ui_loc != null) {
            //    lstDebugOut.Items.Add("loc found: " + ui_loc.ToString());            
            //} else {
            //    lstDebugOut.Items.Add("no loc found");
            //}

            //var coll = _cchar.PropertyCollection;
            //lstDebugOut.Items.Add($"{coll.Name} : {coll.OwnerId.ToString()} : {coll.Properties} : {coll.PropertyCollectionId.ToString()}");


            //var entities = _provider.GetEntities();

            //foreach (var entity in entities) {
            //    lstDebugOut.Items.Add(" ");
            //    lstDebugOut.Items.Add($"({entity.InstanceId}) {entity.Name}");
            //    lstDebugOut.Items.Add($"\t[NPC?: {entity.IsNpc()}, PC?: {entity.IsPlayer()}, Mons?: {entity.IsMonster()}, deleted?: {entity.IsDeleted}]");
            //    lstDebugOut.Items.Add($"\t[OwnerID: {entity.OwnerId}, WeenieID: {entity.WeenieId}, MSB: {entity.MostSignificantByte}, Pos: {entity.Position}]");
            //    if (entity.InstanceProperties != null) { lstDebugOut.Items.Add($"\t[IColl: {entity.InstanceProperties.Name}]"); }
            //    if (entity.WeeniePropertyCollection != null) { lstDebugOut.Items.Add($"\t[WColl: {entity.WeeniePropertyCollection.Name}]"); }
            //    if (entity.PropertyCollection != null) { 
            //        lstDebugOut.Items.Add($"\t[PColl: {entity.PropertyCollection.Name}]");
            //        //lstDebugOut.Items.Add($"\t{entity.PropertyCollection.Get}");

            //    }

            //}

            //var datfile_list = _clientGamelogic.FileList;
            //var all_props = from datfile in datfile_list where $"{datfile.Id:X8}"[0] == '7' && $"{datfile.Id:X8}"[1] == '9' select _propertyMaster.GetPropertyCollection(datfile.Id);

            //StreamWriter stream = new StreamWriter(path: "./output.text", options: new FileStreamOptions { Access = FileAccess.Write, Mode = FileMode.OpenOrCreate});

            //foreach (var prop_set in all_props) {

            //    stream.WriteLine($"{prop_set.PropertyCollectionId:X8}: {prop_set.Name}");
            //}


        }
    }
} 
