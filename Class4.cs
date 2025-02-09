#include <iostream>
#include <cmath>
#include <vector>
#include <string>
#include <sstream>

class Shape
{
    protected:
    double x;
    double y;

    public:
    Shape(double x_coord = 0, double y_coord = 0) : x(x_coord), y(y_coord) { }

    void move(double dx, double dy)
    {
        x += dx;
        y += dy;
    }

    virtual std::string ToString() const = 0; // Pure virtual function

    virtual void Show() const = 0; // Pure virtual function (abstract)
};

class Line : public Shape
{
private:
    double x2;
double y2;

public:
    Line(double x1 = 0, double y1 = 0, double x2_coord = 0, double y2_coord = 0): Shape(x1, y1), x2(x2_coord), y2(y2_coord) { }

void Show() const override {
        std::cout << ToString() << std::endl;
    }

    std::string ToString() const override {
        std::stringstream ss;
ss << "Line: (" << x << ", " << y << ") - (" << x2 << ", " << y2 << ")";
return ss.str();
    }
};

class Circle : public Shape
{
private:
    double radius;

public:
    Circle(double x_coord = 0, double y_coord = 0, double r = 0): Shape(x_coord, y_coord), radius(r) { }

void Show() const override {
        std::cout << ToString() << std::endl;
    }

    std::string ToString() const override {
        std::stringstream ss;
ss << "Circle: Center (" << x << ", " << y << "), Radius " << radius;
return ss.str();
    }
};

class Rectangle : public Shape
{
private:
    double width;
double height;

public:
    Rectangle(double x1 = 0, double y1 = 0, double w = 0, double h = 0): Shape(x1, y1), width(w), height(h) { }

void Show() const override {
        std::cout << ToString() << std::endl;
    }

    std::string ToString() const override {
        std::stringstream ss;
ss << "Rectangle: Top-left (" << x << ", " << y << "), Width " << width << ", Height " << height;
return ss.str();
    }
};


class PolyLine : public Shape
{
private:
    std::vector<std::pair<double, double>> points;

public:
     PolyLine(double x_coord = 0, double y_coord = 0) : Shape(x_coord, y_coord) { }

void addPoint(double px, double py)
{
    points.push_back({ px, py});
}

void Show() const override {
        std::cout << ToString() << std::endl;
    }

    std::string ToString() const override {
        std::stringstream ss;
ss << "PolyLine: ";
for (const auto&point : points) {
            ss << "(" << point.first << ", " << point.second << ") ";
        }
        return ss.str();
    }

    void move(double dx, double dy) override
{
    Shape::move(dx, dy); // Move the starting point
    for (auto & point : points)
    {
        point.first += dx;
        point.second += dy;
    }
}
};

int main()
{
    Line l(1, 2, 3, 4);
    Circle c(5, 6, 2);
    Rectangle r(7, 8, 4, 5); // Example width and height
    PolyLine pl(13, 14);
    pl.addPoint(15, 16);
    pl.addPoint(17, 18);

    l.Show();
    c.Show();
    r.Show();
    pl.Show();

    l.move(1, 1);
    c.move(1, 1);
    r.move(1, 1);
    pl.move(1, 1);

    l.Show();
    c.Show();
    r.Show();
    pl.Show();


    return 0;
}
