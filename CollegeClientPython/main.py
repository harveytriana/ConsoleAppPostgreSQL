from rest_client import RestClient
from models import Book

_rc = RestClient('http://127.0.0.1:5000/')


def GetRandomBook():
    print('GET RANDOM BOOK')
    book = _rc.get_random_object('college/api/something')
    # display
    if book is not None:
        print(f'Mapped Book: {book} | {book.link}')
    else:
        print("returns None.")

def GetBook():
    print('GET BOOK 9')
    book = _rc.get_object('api/books', 9)
    # display
    if book is not None:
        print(f'Mapped Book: {book} | {book.link}')
    else:
        print("returns None.")

if __name__ == "__main__":
    print('\nClient of Django REST API')
    print('-------------------------')
    GetRandomBook()
    GetBook()