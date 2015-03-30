using ICities;
using System;
using System.Collections.Generic;
namespace WufireNameGenerator
{
	public class LoadingExtension : LoadingExtensionBase
	{
		private void AdjustBuidingAI (BuildingInfo buildinginfo, Dictionary<Type, Type> componentRemap)
		{
			BuildingAI component = buildinginfo.GetComponent<BuildingAI> ();
			Type type = component.GetType ();
			Type type2;
			if (componentRemap.TryGetValue (type, out type2))
			{
				BuildingAI buildingAI = buildinginfo.gameObject.AddComponent (type2) as BuildingAI;
				buildingAI.m_info = buildinginfo;
				buildinginfo.m_buildingAI = buildingAI;
				DebugOutputPanel.AddMessage(ColossalFramework.Plugins.PluginManager.MessageType.Message, "Successfully patched building info with " + type2);
			}
		}
		
		public override void OnLevelLoaded (LoadMode mode)
		{
			if (mode == LoadMode.LoadGame || mode == LoadMode.LoadMap)
			{
				BuildingNameGenerator.Initialize();
				Dictionary<Type, Type> dictionary = new Dictionary<Type, Type> ();
				dictionary.Add (typeof(CommercialBuildingAI), typeof(CommercialBuildingNameMod));
				dictionary.Add (typeof(OfficeBuildingAI), typeof(OfficeBuildingNameMod));
				dictionary.Add (typeof(IndustrialBuildingAI), typeof(IndustrialBuildingNameMod));
				Dictionary<Type, Type> componentRemap = dictionary;
				int num = PrefabCollection<BuildingInfo>.PrefabCount ();
				DebugOutputPanel.AddMessage (ColossalFramework.Plugins.PluginManager.MessageType.Message, "Found " + num + " building infos.");
				uint num2 = 0u;
				while ((ulong)num2 < (ulong)((long)num))
				{
					BuildingInfo prefab = PrefabCollection<BuildingInfo>.GetPrefab (num2);
					this.AdjustBuidingAI (prefab, componentRemap);
					num2 += 1u;
				}
			}
		}
	}
}

