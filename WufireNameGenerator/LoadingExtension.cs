using ICities;
using System;
using System.Collections.Generic;
namespace WufireNameGenerator
{
  public class LoadingExtension : LoadingExtensionBase
  {
    private void AdjustBuildingAI (BuildingInfo buildinginfo, Dictionary<Type, Type> componentRemap)
    {

      BuildingAI component = buildinginfo.GetComponent<BuildingAI> ();
      Type type = component.GetType ();
      Type type2;
      try {
        if (componentRemap.TryGetValue (type, out type2))
        {
          BuildingAI buildingAI = buildinginfo.gameObject.AddComponent (type2) as BuildingAI;
          buildingAI.m_info = buildinginfo;
          buildinginfo.m_buildingAI = buildingAI;
        }
      } catch (Exception e) {
        DebugOutputPanel.AddMessage(ColossalFramework.Plugins.PluginManager.MessageType.Error, "BuildingAI adjustment error: " + e.ToString());
      }
    }

    public override void OnLevelLoaded (LoadMode mode)
    {
      if (mode == LoadMode.LoadGame || mode == LoadMode.NewGame)
      {
        BuildingNameGenerator.Initialize();

        Dictionary<Type, Type> dictionary = new Dictionary<Type, Type> ();
        dictionary.Add (typeof(CommercialBuildingAI), typeof(CommercialBuildingAIMod));
        dictionary.Add (typeof(OfficeBuildingAI), typeof(OfficeBuildingAIMod));
        dictionary.Add (typeof(IndustrialBuildingAI), typeof(IndustrialBuildingAIMod));
        dictionary.Add (typeof(ResidentialBuildingAI), typeof(ResidentialBuildingAIMod));
        Dictionary<Type, Type> componentRemap = dictionary;

        for(int i = 0; i < PrefabCollection<BuildingInfo>.PrefabCount(); i++) {
          BuildingInfo prefab = PrefabCollection<BuildingInfo>.GetPrefab((uint)i);
          if (prefab != null) {
            this.AdjustBuildingAI (prefab, componentRemap);
          }
        }
      }
    }
  }
}
 
