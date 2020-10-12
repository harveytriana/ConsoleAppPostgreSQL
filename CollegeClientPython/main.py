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


def CreateBook():
    print('CREATE BOOK')
    # book = Book(id=0,
    #             isbn='9789587231939',
    #             author='Jorge Isaacs',
    #             image_link='',
    #             language='English',
    #             link='https://bit.ly/3iNMDiY',
    #             pages=900,
    #             title='María',
    #             year=1867)
    book = Book(id=0,
                isbn='9789587231940',
                author='Laura Restrepo',
                image_link='',
                language='Spanish',
                link='https://es.wikipedia.org/wiki/Delirio_(novela)',
                pages=303,
                title='Delirio',
                year=2003)
    result = _rc.post_object('api/books/', book)
    if result is not None:
        print(f'Created book: {result}, id: {result.id}')
    else:
        print(f'{book} was not created.')


def UpdateBook():
    print('EDIT BOOK')
    pk = 104
    book = Book(
        id=pk,
        isbn='9789587231939',
        author='Jorge Isaacs',
        image_link='',
        language='Spanish',  # change
        link='https://bit.ly/3iNMDiY',
        pages=312,
        title='María',
        year=1867)
    result = _rc.put_object('api/books/', book, pk)
    if result:
        print(f'Updated Book: {result}, id: {pk}')
    else:
        print(f'{book} was not updated..')


if __name__ == "__main__":
    print('\nClient of Django REST API')
    print('-------------------------')
    # GetRandomBook()
    # GetBook()
    # CreateBook()
    UpdateBook()
