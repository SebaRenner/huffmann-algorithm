# Huffmann Text Decompression Algorithm
Huffmann coding is a loseless text compression algorithm. It substitutes each character in a text with a binary code. The higher the frequency of a character in the text, the lower the code.
It's mathematically proven that it's the optimal algorithm of its kind*

\* Symbol-by-symbol coding with a known input probability distribution

## Algorithm
1. Count the frequency of each character in the input text.
1. Combine the characters with the smallest frequency and sum up their frequency. Repeat until you only have 1 character left.
1. For each character traverse the tree down from the root. If the character is contained in the left child add a "0", if he's contained in the right child add a "1". Traverse until you've reached the original character node. The path from the root represents the huffmann code of this character.
1. Substitute each character in the input text with its huffmann code representation.
