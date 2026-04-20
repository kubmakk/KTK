#include <stdio.h>

int collatz_step(int current)
{
    if (current % 2 == 0)
    {
        return current / 2;
    }
    else
    {
        return 3 * current + 1;
    }
}

void print_collatz_sequence(int start)
{
    int current = start;
    int steps = 1;
    printf("Последовательность Коллатца для числа %d\n", current);
    printf("%d", current);
    while (current != 1){
        current = collatz_step(current);
        printf(" -> %d", current);
        steps++;
    }
    printf("\nкол-во шагов: %d", steps);
}

int get_starting_number(){
    int n;
    do{
        printf("Введите стартовое число (> 0): ");
        scanf("%d", &n);
        if (n <= 0)
            printf("Ошибка!\n");
    } while (n <= 0);

    return n;
}

int main(){
    int number = get_starting_number();
    print_collatz_sequence(number);

}