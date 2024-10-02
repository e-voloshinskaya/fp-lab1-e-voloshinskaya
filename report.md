# Lab 1 report

## Functional Programming

### Student: 
|Name        |Group      | # in group list |Mark|
|------------|-----------|-----------------|----|
|Voloshinskaya Evgeniya|М8О-406Б-21| 8              |    |

## Solving simple computational problems in functional style

### Task 1

According to my number in group list (8), I have the following function:
$$f(x) = {1 \over 2x - 5}$$
and it's Taylor expansion
$$f(x) = -{1 \over 5} - {2x \over 5^2} - … - {2^{n-1}x^{n-1} \over 5^n}$$


Calculating each member of the Taylor series requires factorial operation, which 
time complexity is $O(n)$, therefore the time complexity of naive approach is 
$O(n^2)$. The main idea of efficient scheme is that we don't need to count the
factorial for each member, since we can count the nth term of the Taylor 
series using the (n-1)th member:
$$t_n = t_{n-1}{2x \over 5}$$
where $t_n$ is the nth member of the Taylor series. Time complexity of calculating 
every single member is now constant, so calculating the entire series is 
$O(n)$, which is way better than $O(n^2)$ of the naive method. 


The result of my F# program taylor.fsx
is the following table:

|   x   |  Builtin  |     Naive Taylor     | # terms |     Smart Taylor    | # terms |
|-------|-----------|----------------------|---------|---------------------|---------|
|   0.00|  -0.200000|             -0.200000|        2|            -0.200000|        2|
|   0.20|  -0.217391|             -0.217391|        6|            -0.217391|        6|
|   0.40|  -0.238095|             -0.238095|        8|            -0.238095|        8|
|   0.60|  -0.263158|             -0.263157|       10|            -0.263157|       10|
|   0.80|  -0.294118|             -0.294117|       13|            -0.294117|       13|
|   1.00|  -0.333333|             -0.333332|       15|            -0.333332|       15|
|   1.20|  -0.384615|             -0.384615|       19|            -0.384615|       19|
|   1.40|  -0.454545|             -0.454545|       24|            -0.454545|       24|
|   1.60|  -0.555556|             -0.555555|       31|            -0.555555|       31|
|   1.80|  -0.714286|             -0.714285|       43|            -0.714285|       43|
|   2.00|  -1.000000|             -0.999999|       63|            -0.999999|       63|

### Task 2

Three equations I've got to solve (8, 9, 10 from the list):
1. $$0.6\cdot3^x - 2.3x - 3 = 0$$
2. $$x^2 - \ln(1+x)-3 = 0$$
3. $$2x\cdot sinx - cosx = 0$$

### Bisection method

This method requires determining the boundaries of the segment on which the root
of the equation is located. Also, the function must be monotone on this segment.

We then calculate the value of the function in the middle of this segment and
replace the right or left boundary of the segment with its middle (depending on
the interval where the function changes its sign). With each iteration, the length
of the segment will decrease by a factor of two, and soon we will obtain the root
of the equation with the required approximation.

### Iterations method

First of all we need to express $x = \varphi (x)$ from the original equation 
$f(x) = 0$.

$\varphi (x)$ should satisfy the conditions:
$$\varphi (x) \in [a, b], \forall x \in [a, b]$$
$$\exists q: |\varphi' (x)| \leq q < 1, \forall x \in [a, b]$$


The resulting equations are:
1. $$x = log_3({5 \over 3} (2.3x + 3)) = {ln({5 \over 3} (2.3x + 3)) \over ln(3)}$$
2. $$x = \sqrt{ln(1+ x) + 3}$$
3. $$x = {1 \over 2arctg(x)}$$

Then we need to calculate $x_n = \varphi(x_{n - 1})$ choosing $x_0$ close 
to the original root. Usually it's the midpoint of the segment.
The more is $n$ - the better precision of solution.

### Newton method

Newton method is a special case of iterations method, where we choose 
$\varphi(x) = x - {f(x)\over f'(x)}$. We calculate differential of 
every function:
1. $$f'(x) =  0.6\cdot ln3\cdot 3^x - 2.3$$
2. $$f'(x) = 2x - {1 \over (1+x)}$$
3. $$f'(x) = 3sin x + 2x\cdot cosx$$

The result of my F# program equations.fsx
is the following table:

| #func | Dichotomy | Iterations |  Newton   |
|-------|-----------|------------|-----------|
|   1   |   2.41998 |    2.41998 |   2.41998 |
|   2   |   2.02669 |    2.02669 |   2.02669 |
|   3   |   0.65327 |    0.76538 |   0.65327 |

Unfortunately, I was unable to manually find the suitabe function $\varphi_3 (x)$ for the segment $[0.4, 1]$, but I managed to calculate roughly. The function in Newton's method works right.

### Conclution

Having done the laboratory work, I got acquainted with functional programming
on the example of F# language, and also remembered how to find the value of a
function using its Taylor series expansion and three methods of solving equations:
bisection method, iteration method and Newton's method.

