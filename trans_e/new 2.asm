Zadanie:
Napisz funkcję która:
w tablicy int tablia[], której koniec oznaczony jest znakiem 0, znajdzie liczbę wystąpień elementu int element


;Musimy napisać funkcję więc zmienne przekazane do funkcji muszą być na stosie poniżej deklaracja zmiennych

tablica DCD tutaj po przecinku elementy tablicy, 0 ; zero znak końca tablicy
element DCD x ; gdzie X to szukany element w tablicy
wynik DCD 0; zmienna wyniki iniciowana 0


;pomijam petle main bo pominalem na kolosie bo uznalem ze jak mam napisac funkcje to sama funkcje


find_element
	LDR R0,=tablica ;load register, załaduj rejestr operator dwuargumentowy do_jakiego_rejestru,co do rejestru r0, element DCD tablica	
	LDR R1,=element ;jw
	LDR R2,=wyniki  ;jw
	MOV R4,#0		;R4 to będzie counter liczny wystąpień danego elemetu, zainiciowany zerem
	CMP R1,#0		;obsluga bledow, porównaj R1 ze znakiem końca tablicy
	BEQ while_end 	;jak użytkownik wprowadził znak końca tablicy jako element do policzenia to wyjść z funkcji, w tym wypadku przejdź na konieć pętli while z wynikiem 0
	
while_loop			;do przechodzenia po tablicy
	LDR R3,[R0],#4 	;do R3 załaduj element R0 i przeszuń o 4 bity, chodzi o to, żeby załadować bieżący element rejestru do zmiennej tymczasowej i "wskaźnik kolejnego elemetu przesunąć na następny stąd #4 do przesunięcia o 4 bity"
	CMP R3,#0		;porownanie biezacego elementu ze znakiem końca tablicy
	BEQ while_end	;Branch if equal jeżeli znak biezacy to znak końca tablicy to przerwij petle
	CMP R3,R1 		;Porównaj element szukany z elementem biężącym tablicy
	BNE skipped_incrementing		;branch not equal, jeżeli nie jest równe to przeskocz to etykiety ,która omija inkrementacje countera R4
	ADD R4,#1 		;Tutaj wejdziemy tylko jak R3 == R1
skipped_incrementing ;tutaj przeskoczymy dodawanie jak R3 != R1
	B while_loop 	;petla powrót na początek while'a
while_end
	STR R4,R2 ;zapisz wyniki czyli counter czyli sume wszystkich wystąpień elementu do R2 czyli do zmiennej wyniki
	BX LR		;powrót to głównego programu BX LR musi się znajdować na końcu każdej funkcji
	
	
	
	