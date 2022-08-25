using System.Collections.Generic;

namespace _3Dgraphics
{
    public class Scene
    {
        public List<Object3> Objects { get; set; } 

        public Scene(params Object3[] Objects)
        {
            this.Objects = new List<Object3>(Objects);
        }
    }
}
