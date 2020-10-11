import requests
import json
# hard code
from models import Book, Person

class RestClient():
    ''' REST Samples '''
    def __init__(self, api_root):
        self.api_root = api_root

    def sample_get(self, route):
        try:
            url = self.api_root + route
            response = requests.get(url)
            # a jeson dictionary
            json_dict = response.json()
            # map to python object
            return Book(**json_dict)
        except:
            return None

    def basic_sample(self):
        person_string = '{"name": "Bob", "age": 25}'
        # to json dictionay
        person_dict = json.loads(person_string)
        # to object
        person_object = Person(**person_dict)

        print(person_object)