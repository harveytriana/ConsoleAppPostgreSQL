from rest_client import RestClient
from models import Book

if __name__ == "__main__":
    p = RestClient('http://127.0.0.1:5000/')
    print('GET')
    book = p.sample_get('college/api/something')

    # display
    print(f'Mapped Book: {book} | {book.link}')

