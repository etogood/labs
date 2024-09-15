#include <iostream> 
#include <cmath> 
#include <iomanip> 
#include <math.h> 

using namespace std;

void iter(double x, double y, double e)
{
    double x1, y1;
    int iter = 0;
    while (true)
    {
        x1 = cos(y + 0.5) - 2;
        y1 = (sin(x) - 1) / 2; 
        if (abs(x1 - x) <= e && abs(y1 - y) <= e) {
            break;
        }
        iter++;
        x = x1;
        y = y1;
    }
    cout << "x = " << x << endl << "y = " << y << endl << "Iterations: " << iter << endl;
}

void main()
{
    double x, y, e;
    cout << "x: ";
    cin >> x;
    cout << "y: ";
    cin >> y;
    cout << "eps: ";
    cin >> e;

    iter(x, y, e);
}
