import requests
import json
# hard code
from models import Book, Person

class RestClient():
    ''' HOW TO USE AN API REST OF DJANGO '''
    def __init__(self, api_root):
        self.api_root = api_root

    def get_object(self, route, pk):
        try:
            url = self.api_root + route
            #? what?
            # response = requests.get(url, params={'id': pk})
            #? ok
            response = requests.get(url + f'/{pk}')
            if response.status_code == requests.codes.OK: # 200
                # json dictionary
                json_dict = response.json()
                # map to python object
                return Book(**json_dict)
        except:
            print('...Something went wrong')
        return None

    def post_object(self, route, object):
        try:
            url = self.api_root + route

            dict = json.dumps(object.__dict__)
            headers = {'Content-type': 'application/json'}
            
            response = requests.post(url, data=dict, headers=headers)
            if response.status_code == requests.codes.created: # 201
                # a json dictionary
                json_dict = response.json()
                # map to python object
                return Book(**json_dict)
        except:
            print('...Something went wrong')
        return None

    def put_object(self, route, object, pk):
        try:
            url = self.api_root + route + str(pk) + '/'

            dict = json.dumps(object.__dict__)
            headers = {'Content-type': 'application/json'}
            
            response = requests.put(url, data=dict, headers=headers)
            if response.status_code == requests.codes.OK: # 200
                return True
        except:
            print('...Something went wrong')
        return False

    def delete_object(self, route, pk):
        try:
            url = self.api_root + route + f'/{pk}'
            response = requests.delete(url)
            if response.status_code == requests.codes.no_content: # 204
                return True
        except:
            print('...Something went wrong')
        return False        

    def get_random_object(self, route):
        try:
            url = self.api_root + route
            response = requests.get(url)
            # a jeson dictionary
            json_dict = response.json()
            # map to python object
            return Book(**json_dict)
        except:
            print('...Something went wrong')
        return None

    def basic_sample(self):
        person_string = '{"name": "Bob", "age": 25}'
        # to json dictionay
        person_dict = json.loads(person_string)
        # to object
        person_object = Person(**person_dict)

        print(person_object)