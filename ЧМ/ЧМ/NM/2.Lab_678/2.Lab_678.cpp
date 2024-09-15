#include <iostream>

double exact_value = 15.5687;

double bottom_value = 1;
double top_value = 100;

double f(double x) {
    return (sqrt(1 + 5 * log(x))) / x;
}

double middle_rect(int n) {
    double h = (top_value - bottom_value) / n;

    double it = bottom_value;

    double sum = 0;

    for (size_t i = 0; i < n; i++) 
    {
        sum += f(it + h/2);
        it += h;
    }

    sum *= h;
    
    return sum;
}

double trapeze(int n) {
    double h = (top_value - bottom_value) / n;

    double it = bottom_value;

    double sum = 0;

    for (size_t i = 0; i < n; i++)
    {
        sum += (f(it) + f(it+h)) / 2;
        it += h;
    }
    
    sum *= h;

    return sum;
}

double simpson(int n) {
    double h = (top_value - bottom_value) / n;

    double it = bottom_value;

    double sum = 0;

    sum += f(bottom_value) + f(top_value);

    for (size_t i = 1; i < n; i++)
    {
        it += h;
        if (i % 2 == 0) sum += 2 * f(it);
        else sum += 4 * f(it);
    }
    
    sum *= h / 3;

    return sum;
}

double average_errors(float errors[])
{
    double sum = 0;
    for (int i = 0; i < 9; i++)
        sum += abs(errors[i] - errors[i + 1]);
    return std::pow(sum / 10, -1);
}

int main()
{
    int n[10] = { 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048 };

    std::cout << "Exact value = " << exact_value << std::endl;
    std::cout << std::endl;

    //std::cout << "----- MIDDLE RECTANGLES METHOD -----" << std::endl;
    //
    //double mr = middle_rect();

    //std::cout << "Solved integral: " << mr << std::endl;
    //std::cout << "Error: " << abs(exact_value - mr) << std::endl;

    //std::cout << std::endl;
    //std::cout << std::endl;

    std::cout << "----- TRAPEZE METHOD -----" << std::endl;

    std::cout << "n\tIntegral\tError\t\tAccuracy\n\n";

    float tr_errors[10];
    float prev_error = 0;

    for (size_t i = 0; i < 10; i++)
    {
        float integral = round(trapeze(n[i]) * 10000)/10000;
        float error = round(abs(exact_value - integral) * 10000)/10000;
        std::cout << n[i] << "\t" << integral << "\t\t" << error << "\t\t" << prev_error / error << std::endl;
        tr_errors[i] = error;
        prev_error = error;
    }

    std::cout << std::endl;
    std::cout << std::endl;

    std::cout << "----- SIMPSON METHOD -----" << std::endl;
    
    std::cout << "n\tIntegral\tError\t\tAccuracy\n\n";

    float sm_errors[10];
    prev_error = 0;

    for (size_t i = 0; i < 10; i++)
    {
        float integral = simpson(n[i]);
        float error = abs(exact_value - integral);
        std::cout << n[i] << "\t" << integral << "\t\t" << error << "\t\t" << prev_error / error << std::endl;
        sm_errors[i] = error;
        prev_error = error;

    }

    std::cout << std::endl;
    std::cout << std::endl;
}