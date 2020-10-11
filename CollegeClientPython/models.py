class Book():
    def __init__(self, id, isbn, author, image_link, language, link, pages, title, year):
        self.id = id
        self.isbn = isbn
        self.author = author
        self.image_link = image_link
        self.language = language
        self.link = link
        self.pages = pages
        self.title = title
        self.year = year

    def __str__(self):
        return f'{self.title}, {self.author}'

class Person():
    def __init__(self, name, age):
        self.name = name
        self.age = age

    def __str__(self):
        return f'{self.name}, {self.age}'