namespace ConsoleApp3;

public class Color {
    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }
    public int Alpha { get; set; }

    public Color(int red, int green, int blue, int alpha = 255) {
        Red = red;
        Green = green;
        Blue = blue;
        Alpha = alpha;
    }

    public int GetGrayscale() {
        return (Red + Green + Blue) / 3;
    }
}

public class Ball {
    public int Size { get; private set; }
    public Color Color { get; set; }
    private int throwCount;

    public Ball(int size, Color color) {
        Size = size;
        Color = color;
    }

    public void Pop() {
        Size = 0;
    }

    public void Throw() {
        if (Size > 0) throwCount++;
    }

    public int GetThrowCount() {
        return throwCount;
    }
}
