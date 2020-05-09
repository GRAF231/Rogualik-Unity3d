namespace TheGame
{
    public static class Input
    {
        public static short Horizontal { get; set; }
        public static short Vertical { get; set; }

        public delegate void KeyPressHandler();
        public static event KeyPressHandler E_Pressed;
        public static bool E_PressedBool { get; set; }

        static Input()
        {
            Horizontal = 0;
            Vertical = 0;
        }

        public static void Remote()
        {
            Horizontal = 0;
            Vertical = 0;

            //if (Keyboard.IsKeyPressed(Keyboard.Key.E))
            //{
            //    if (!E_PressedBool) { E_PressedBool = true; E_Pressed(); }; 
            //}
            //else E_PressedBool = false;


            //if (Keyboard.IsKeyPressed(Keyboard.Key.W)) Vertical -= 1;
            //if (Keyboard.IsKeyPressed(Keyboard.Key.A)) Horizontal -= 1;
            //if (Keyboard.IsKeyPressed(Keyboard.Key.S)) Vertical += 1;
            //if (Keyboard.IsKeyPressed(Keyboard.Key.D)) Horizontal += 1;
        }
    }
}
