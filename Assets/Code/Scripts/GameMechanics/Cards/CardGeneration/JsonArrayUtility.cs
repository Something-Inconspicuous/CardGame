using UnityEngine;
using System.Collections;
using System;

namespace GameMechanics.Cards.CardGeneration {


    public static class JsonArrayUtility {

        public static T[] FromJson<T>(string json) {
            Wrapper<T> wrapper = UnityEngine.JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(T[] array, bool prettyPrint = false) {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return UnityEngine.JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [Serializable]
        private class Wrapper<T> {
            public T[] Items;
        }
    }
}