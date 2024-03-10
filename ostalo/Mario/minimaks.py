# lista računa koji treba platiti
import datetime
import math


racuni = [{'naziv': 'Prijemni ispit', 'iznos': 1000, 'rok_placanja': '2023-06-01'},
          {'naziv': 'Školarina - sufinansirajući studenti', 'iznos': 5000, 'rok_placanja': '2023-06-15'},
          {'naziv': 'Školarina - samofinansirajući studenti', 'iznos': 7000, 'rok_placanja': '2023-06-15'},
          {'naziv': 'Upis semestra', 'iznos': 1000, 'rok_placanja': '2023-09-01'},
          {'naziv': 'Upisni materijal', 'iznos': 500, 'rok_placanja': '2023-09-01'},
          {'naziv': 'Polaganje ispita', 'iznos': 500, 'rok_placanja': '2023-10-01'},
          {'naziv': 'Nastavni plan i program', 'iznos': 2000, 'rok_placanja': '2023-09-15'},
          {'naziv': 'Obnova godine', 'iznos': 3000, 'rok_placanja': '2023-10-01'},
          {'naziv': 'Štampanje diplome', 'iznos': 200, 'rok_placanja': '2023-12-01'},
          {'naziv': 'Duplikat indeksa', 'iznos': 100, 'rok_placanja': '2023-12-01'},
          {'naziv': 'Prepis ocjena (uvjerenje)', 'iznos': 500, 'rok_placanja': '2023-12-01'},
          {'naziv': 'Uplata za prepis i priznavanje ispita na drugi studijski program Univerziteta u Banjoj Luci', 'iznos': 1000, 'rok_placanja': '2023-11-01'}]

# funkcija koja računa heuristiku
def heuristika(stanje):
    # ovde možete implementirati funkciju koja računa heuristiku na osnovu datuma roka plaćanja
    # što je rok bliži, to bi heuristika trebala biti lošija
    # ovde je heuristika definisana kao zbir dana kašnjenja za svaki račun
    kašnjenje = 0
    for r in stanje:
        if r['iznos'] > 0:
            dani = (datetime.datetime.strptime(r['rok_placanja'], '%Y-%m-%d') - datetime.datetime.now()).days
            if dani < 0:
                kašnjenje += abs(dani)
    return kašnjenje

# funkcija koja vrši potez
def izvrsi_potez(stanje, potez):
    # ovde se vrši izvršavanje plaćanja za dati potez
    # u ovom primjeru, potez se definiše kao broj racuna koji će biti plaćen
    # potez je broj od 0 do len(stanje), gde je 0 - ne plaća se ništa, a n - plaćaju se prvih n računa koji nisu plaćeni
    novi_stanje = stanje.copy()
    placeno = 0
    for i in range(potez):
        r = novi_stanje[i]
        if r['iznos'] > 0:
            placeno += r['iznos']
            r['iznos'] = 0
    # ovde se može dodati i logika za obračun kamata i troškova obrade plaćanja
    return novi_stanje, placeno



#funkcija koja proverava da li je igra završena
def igra_završena(stanje):
    # igra je završena ako su svi računi plaćeni
    return all([r['iznos'] == 0 for r in stanje])

#funkcija koja vraća listu mogućih poteza
    
def moguci_potezi(stanje):
    # mogući potezi su sve kombinacije plaćanja prvih n računa koji nisu plaćeni
    moguci = []
    for i in range(len(stanje) + 1):
        moguci.append(i)
    return moguci


def minimax(stanje, dubina, igrac, alfa, beta):
    if dubina == 0 or igra_završena(stanje):
        return None, heuristika(stanje) if igrac == 'max' else -heuristika(stanje)
    
    if igrac == 'max':
        najbolji_potez = None
        najbolja_vrednost = float('-inf')
        for potez in moguci_potezi(stanje):
            novo_stanje, vrednost = izvrsi_potez(stanje, potez)
            if vrednost > najbolja_vrednost:
                najbolja_vrednost = vrednost
                najbolji_potez = potez
            alfa = max(alfa, vrednost)
            if beta <= alfa:
                break
        return najbolji_potez, najbolja_vrednost
    else:
        najbolji_potez = None
        najbolja_vrednost = float('inf')
        for potez in moguci_potezi(stanje):
            novo_stanje, vrednost = izvrsi_potez(stanje, potez)
            if vrednost < najbolja_vrednost:
                najbolja_vrednost = vrednost
                najbolji_potez = potez
            beta = min(beta, vrednost)
            if beta <= alfa:
                break
        return najbolji_potez, najbolja_vrednost


#testiranje algoritma
stanje = [
    {'naziv': 'Prijemni ispit', 'iznos': 500},
    {'naziv': 'Školarina - sufinansirajući studenti', 'iznos': 1500},
    {'naziv': 'Školarina - samofinansirajući studenti', 'iznos': 2000},
    {'naziv': 'Upis semestra', 'iznos': 500},
    {'naziv': 'Upisni materijal', 'iznos': 50},
    {'naziv': 'Polaganje ispita', 'iznos': 200},
    {'naziv': 'Nastavni plan i program', 'iznos': 100},
    {'naziv': 'Obnova godine', 'iznos': 1000},
    {'naziv': 'Štampanje diplome', 'iznos': 50},
    {'naziv': 'Duplikat indeksa', 'iznos': 20},
    {'naziv': 'Prepis ocjena', 'iznos': 50},
    {'naziv': 'Uplata za prepis i priznavanje ispita na drugi studijski program Univerziteta u Banjoj Luci', 'iznos': 300}
]

potez, vrednost = minimax(stanje, 3, 'max', -math.inf, +math.inf)
print('Najbolji potez: {}, Očekivana vrednost: {}'.format(potez, vrednost))

#izvršavanje najboljeg poteza
novo_stanje, placeno = izvrsi_potez(stanje, potez)
print('Plaćeno: {}'.format(placeno))
print('Novo stanje:')
print(novo_stanje)

while not igra_završena(stanje):
    print('Trenutno stanje:')
    print(stanje)
    potez, _ = minimax(stanje, 3, 'max', -math.inf, +math.inf)
    print('Predloženi potez: {}'.format(potez))
    odgovor = input('Unesite broj računa koji želite da platite (0 za kraj igre): ')
    if odgovor == '0':
        break
    try:
        potez = int(odgovor)
    except ValueError:
        print('Pogrešan unos!')
        continue
    if potez not in moguci_potezi(stanje):
        print('Pogrešan unos!')
        continue
    novo_stanje, placeno = izvrsi_potez(stanje, potez)
    print('Plaćeno: {}'.format(placeno))
    stanje = novo_stanje

#print('Kraj igre!')

# pozivanje funkcije za izvršavanje igre
def igraj(stanje):
    igrac = 'max'
    while not igra_završena(stanje):
        if igrac == 'max':
            potez = minimax(stanje, dubina=3, igrac='max', alfa=float('-inf'), beta=float('inf'))[0]
            print(f'Max igrač igra potez: {potez}')
        else:
            potez = int(input('Unesi potez: '))
        stanje, placeno = izvrsi_potez(stanje, potez)
        print(f'Plaćeno: {placeno}')
        print('Stanje:')
        for r in stanje:
            print(f"{r['naziv']}: {r['iznos']} - rok plaćanja: {r['rok_placanja']}")
        igrac = 'min' if igrac == 'max' else 'max'
    print('Kraj igre')

igraj(stanje)
