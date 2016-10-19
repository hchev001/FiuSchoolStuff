select title
from book, wrote, author
where authorfirst = 'John' and authorlast = 'Steinbeck' and author.authornum = wrote.authornum and wrote.bookcode = book.bookcode