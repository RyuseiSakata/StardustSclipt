#include <stdio.h>

/*--- ������s�̒������Ԃ� ---*/
int str_length(const char *s)
{
	int len = 0;

	while (*s++)
		len++;
	return len;
}

int main(void)
{
	char str[128];
  char str1[128];

	printf("文字列を入力してください:");
	scanf("%s", str);
  printf("文字列を入力してください:");
	scanf("%s", str1);

	printf("一つ目\"%s\"\n", str);
  printf("二つ目\"%s\"\n", str);

  if(str_length(str)>str_length(str1)){
    printf("長い方の長さは%d",str_length(str))
  }
  else{
    printf("長い方の長さは%d",str_length(str1))
  }
	return 0;
}
