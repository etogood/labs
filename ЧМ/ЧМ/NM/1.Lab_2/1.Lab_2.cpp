#include <iostream>
#include <math.h>
 
int it_count_dich = 0;
int it_count_simple = 0;
int it_count_newton = 0;
int it_count_chord = 0;

double a, b, x0, eps;

double f(double x) {
    return x*x - 2 * cos(x) + 1;
}

double f_der(double x) {
    return 2 * x + 2 * sin(x);
}

double f_der2(double x) {
    return 2 * cos(x) + 2;
}

double phi(double x) {
    return x - ((x*x - 2 * cos(x) + 1) / 4);
}

double simple_it(double x0, double eps) {
    double x_curr = x0;
    double x_prev;

    std::cout << "Enter \'x0\' (for simple it. method): ";
    std::cin >> x0;

    do {
        it_count_simple++;
        x_prev = x_curr;
        x_curr = phi(x_prev);
    } while (f(x_curr - eps) * f(x_curr + eps) >= 0);

    return x_curr;
}

double dich_it(double a, double b, double eps) {
    double c;
    while (f(a) * f(b) > 0) {

        std::cout << "Enter \'a\' (left): ";
        std::cin >> a;
        std::cout << "Enter \'b\' (right): ";
        std::cin >> b;

        if (f(a) * f(b) > 0) std::cout << "There is no root between these values! Try again:\n";
    }

    do {
        it_count_dich++;
        c = (a + b) / 2.0;
        if (f(a) * f(c) < 0) b = c;
        else if (f(b) * f(c) < 0) a = c;
        else {
            std::cout << "The root is not found" << std::endl;
            return 0;
        }
    } while (f(c - eps) * f(c + eps) >= 0);
    return c;
}

double newton_it() {
    it_count_newton = 0;

    while (f(a) * f(b) > 0) {

        std::cout << "Enter \'a\' (left): ";
        std::cin >> a;
        std::cout << "Enter \'b\' (right): ";
        std::cin >> b;

        if (f(a) * f(b) > 0) std::cout << "There is no root between these values! Try again:\n";
        
        if (f(a) * f_der2(a) > 0) x0 = a;
        else x0 = b;
    }

    double x1 = x0 - f(x0) / f_der(x0);
    while (f(x1 - eps) * f(x1 + eps) >= 0) {
        x0 = x1;
        x1 = x0 - f(x0) / f_der(x0);
        it_count_newton++;
    }

    return x1;
}

double chord_it() {
    it_count_chord = 0;
    double c;

    while (f(a) * f(b) > 0) {

        std::cout << "Enter \'a\' (left): ";
        std::cin >> a;
        std::cout << "Enter \'b\' (right): ";
        std::cin >> b;

        if (f(a) * f(b) > 0) std::cout << "There is no root between these values! Try again:\n";
    }

    do {
        c = a - (b - a) * f(a) / (f(b) - f(a));
        if (f(c) * f(a) < 0)
            b = c;
        else
            a = c;
        it_count_chord++;

    } while (f(c + eps) * f(c - eps) >= 0);

    return c;
}

int main()
{
    std::cout << "Enter \'epsilon\' (accuracy): ";
    std::cin >> eps;
    
    std::cout << std::endl;

    std::cout << "----- NEWTON METHOD -----" << std::endl;

    std::cout << "Root by Newton method: " << newton_it() << std::endl;
    std::cout << "Amount of iterations for Newton method = " << it_count_newton << std::endl;

    std::cout << std::endl;
    std::cout << std::endl;

    std::cout << "----- CHORD METHOD -----" << std::endl;

    std::cout << "Root by Newton method: " << chord_it() << std::endl;
    std::cout << "Amount of iterations for Newton method = " << it_count_chord << std::endl;

    std::cout << std::endl;
    std::cout << std::endl;

    std::cout << "Epsilon (accuracy) = " << eps << std::endl;
}
