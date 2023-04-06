namespace GeoJSON {

	public class GeoJSONObject {

		public string type;

		public GeoJSONObject() {
		}

		public GeoJSONObject(JSONObject jsonObject) {
			if(jsonObject != null)
				type = jsonObject ["type"].stringValue;
		}

		static public FeatureCollection Deserialize(string encodedString) {
			FeatureCollection collection;

			JSONObject jsonObject = new JSONObject (encodedString);
			if (jsonObject ["type"].stringValue == "FeatureCollection") {
				collection = new FeatureCollection (jsonObject);
			} else {
				collection = new FeatureCollection ();
				collection.features.Add (new FeatureObject (jsonObject));
			}

			return collection;
		}

		virtual public JSONObject Serialize () {

			JSONObject rootObject = new JSONObject (JSONObject.Type.Object);
			rootObject.AddField ("type", type);

			SerializeContent (rootObject);

			return rootObject;
		}

		protected virtual void SerializeContent(JSONObject rootObject) {}
	}
}