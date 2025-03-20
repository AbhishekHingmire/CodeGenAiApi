FROM python:3.9-slim

WORKDIR /app

COPY CodeGenAiApi/requirements.txt /app/
RUN pip install -r requirements.txt

COPY CodeGenAiApi/ /app

CMD ["python", "app.py"]
