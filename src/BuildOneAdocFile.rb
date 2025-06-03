require 'asciidoctor'

source = File.read 'UnitTests.adoc'
doc = Asciidoctor::Document.new
reader = Asciidoctor::PreprocessorReader.new doc, source
combined_source = reader.read
File.open('UnitTests.book.adoc', 'w') {|f| f.write combined_source }
