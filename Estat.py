import random 
from scipy.stats import binom
from math import sqrt

melhor_v = 0
melhor_p = 0

for v in range(900, 1000):
    p = 0.80 + 0.18 * (sqrt(1000 - v / 100))
    prob_total = 0 

    for k in range(890, v):
        prob_total += binom.cdf(950, 1000, p)

    if prob_total > melhor_p: 
        melhor_p = prob_total
        melhor_v = v

print (melhor_p)