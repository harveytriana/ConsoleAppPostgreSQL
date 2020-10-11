# https://requests.readthedocs.io/es/latest/
# https://www.youtube.com/results?search_query=Taller+consumir+APIs+con+Python

import requests
import json
from models import Book, Person


class RestClient():
    ''' REST Samples '''
    def __init__(self, api_root):
        self.api_root = api_root

    def json_formatted(self, json_dict):
        ''' Utility: Ident JSON '''
        return json.dumps(json_dict, indent=2)

    def sample_get(self, route):
        url = self.api_root + route
        response = requests.get(url)
        # a jeson dictionary
        json_dict = response.json()
        # display
        print(self.json_formatted(json_dict))
        # map to python object
        book = Book(**json_dict)
        # display
        print(f'Mapped Book: {book} | {book.link}')

    def sample(self):
        person_string = '{"name": "Bob", "age": 25}'
        # to json dictionay
        person_dict = json.loads(person_string)
        # to object
        person_object = Person(**person_dict)

        print(person_object)


if __name__ == "__main__":
    p = RestClient('http://127.0.0.1:5000/')
    print('GET')
    p.sample_get('college/api/something')
