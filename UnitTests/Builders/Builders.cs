namespace UnitTests.Builders
{
    public static class A
    {
        public static PlayerBuilder Player => new PlayerBuilder();
        public static MapBuilder Map => new MapBuilder();
    }
}
