namespace _3Dgraphics
{
    public class IdGenerator
    {
        private int idCount = 0;
        public int SetId()
        {
            idCount++;
            return idCount;
        }
    }
}
