/*Napisati program koji iz datoteke cita dio teksta, rijec po rijec, i unosi u binarno stablo pretrazivanja (max length 1024)
  Ispisati binarno stablo na "inorder" nacin.
  Iz binarnog stabla kreirati dvije datoteke, u prvoj se nalaze sve rijeci koje pocinju sa samoglasnikom
  ,a  u drugoj sve rijeci koje pocinju sa suglasnikom, Rijeci zapisane u datotekama moraju biti sortirane po abecedi*/

#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAX_LENGTH (1024)
#define ERROR_FILEOPEN (-1)
#define ERROR_ALLOCATE (-2)

struct _Tree;
typedef struct _Tree* PositionTree;
typedef struct _Tree {
	char* word;
	PositionTree left;
	PositionTree right;
} tree;

PositionTree readFromFile(PositionTree T, char* filename);
PositionTree createNode(char* word);
PositionTree addToTree(PositionTree T, char* word);
void freeTree(PositionTree T);
void inOrderPrint(PositionTree T);
void addWordsToFile(PositionTree T, FILE* vowelPointer, FILE* consonantPointer);

void addToFiles(PositionTree T, char* vowelFile, char* consonatFile);

int main() {
	PositionTree root = NULL;
	char filename[MAX_LENGTH];

	printf("Input file name (i.e. text.txt): ");
	scanf(" %s", filename);

	root = readFromFile(root, filename);
	inOrderPrint(root);

	addToFiles(root, "vowels.txt", "consonants.txt");


	freeTree(root);

	return 0;
}

PositionTree readFromFile(PositionTree T, char* filename) {

	FILE* filePointer = fopen(filename, "r");
	if (!filePointer) {
		printf("Error while opening file!");
		return ERROR_FILEOPEN;
	}

	char word[MAX_LENGTH];
	while (fscanf(filePointer, "%s", word) == 1) {
		T = addToTree(T, word);
	}

	return T;
}

PositionTree createNode(char* word) {

	PositionTree newNode = (PositionTree)malloc(sizeof(tree));
	if (!newNode) {
		printf("Error while allocating memory!");
		return ERROR_ALLOCATE;
	}

	newNode->word = _strdup(word);
	newNode->left = NULL;
	newNode->right = NULL;

	return newNode;
}

PositionTree addToTree(PositionTree T, char* word) {

	if (T == NULL) {
		return createNode(word);
	}

	if (strcmp(word, T->word) < 0) {
		T->left = addToTree(T->left, word);
	}
	else if (strcmp(word, T->word) >= 0) {
		T->right = addToTree(T->right, word);
	}

	return T;
}

void inOrderPrint(PositionTree T) {
	if (T != NULL) {
		inOrderPrint(T->left);
		printf("%s ", T->word);
		inOrderPrint(T->right);
	}
}

void freeTree(PositionTree T) {
	if (T != NULL) {
		freeTree(T->left);
		freeTree(T->right);
		free(T->word);
		free(T);
	}
}

void addToFiles(PositionTree T, char* vowelFile, char* consonatFile) {

	FILE* vowelPointer = fopen(vowelFile, "w");
	FILE* consonantPointer = fopen(consonatFile, "w");

	if (!vowelPointer || !consonantPointer) {
		printf("Error while opening files!");
		return ERROR_FILEOPEN;
	}

	addWordsToFile(T, vowelPointer, consonantPointer);

	fclose(vowelPointer);
	fclose(consonantPointer);
}

void addWordsToFile(PositionTree T, FILE* vowelPointer, FILE* consonantPointer) {

	if (T != NULL) {
		addWordsToFile(T->left, vowelPointer, consonantPointer);

		if (strchr("aeiouAEIOU", T->word[0]) != NULL) {
			fprintf(vowelPointer, "%s\n", T->word);
		}
		else {
			fprintf(consonantPointer, "%s\n", T->word);
		}

		addWordsToFile(T->right, vowelPointer, consonantPointer);
	}

	printf("Words separated into files!");
}