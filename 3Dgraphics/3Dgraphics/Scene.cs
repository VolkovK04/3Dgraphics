using System.Collections.Generic;

namespace _3Dgraphics
{
    class Scene
    {
        public Scene(params Object3[] Objects)
        {
            this.Objects = new List<Object3>(Objects);
        }
        public List<Object3> Objects { get; set; } 
    }
}
