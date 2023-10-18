# Huffmann Text Compression Algorithm
Huffmann coding is a loseless text compression algorithm. It substitutes each character in a text with a binary code. The higher the frequency of a character in the text, the lower the code.

It's mathematically proven to be the optimal algorithm of its kind*

\* Symbol-by-symbol coding with a known input probability distribution

## Algorithm
### Encoding
1. Count the frequency of each character in the input text.
1. Combine the characters with the smallest frequency and sum up their frequency. Repeat until you only have 1 character left.
1. For each character traverse the tree down from the root. If the character is contained in the left child add a "0", if he's contained in the right child add a "1". Traverse until you've reached the original character node. The path from the root represents the huffmann code of this character.
1. Substitute each character in the input text with its huffmann code representation.

### Decoding
A huffmann encoded text can be decoded in two different ways. Either way requires the substitution table/huffmann tree that was used for encoding the text. 

#### Decoding using Substitution Table
1. Start from the beginning of the encoded text with an empty partial code
1. Add bits to the partial code until there is a matching key in the substitution table.
1. Save the keys character value and remove the partial code from the encoded text.
1. Repeat until no bits are left in the encoded text.

#### Decoding using Tree
1. Travers the tree bit by bit until you land on a leaf node.
1. Save the leafs character value and remove the travered path from the encoded text.
1. Repeat until no bits are left in the encoded text.