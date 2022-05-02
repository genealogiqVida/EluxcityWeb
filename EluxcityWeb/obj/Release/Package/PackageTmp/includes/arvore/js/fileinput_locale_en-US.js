/*!
 * FileInput Brazillian Portuguese Translations
 *
 * This file must be loaded after 'fileinput.js'. Patterns in braces '{}', or
 * any HTML markup tags in the messages must not be converted or translated.
 *
 * @see http://github.com/kartik-v/bootstrap-fileinput
 *
 * NOTE: this file must be saved in UTF-8 encoding.
 */
(function ($) {
    "use strict";

    $.fn.fileinputLocales['pt-BR'] = {
        fileSingle: 'arquivo',
        filePlural: 'arquivos',
        browseLabel: 'Procurar&hellip;',
        removeLabel: 'Remover',
        removeTitle: 'Remover arquivos selecionados',
        cancelLabel: 'Cancelar',
        cancelTitle: 'Interromper envio em andamento',
        uploadLabel: 'Enviar',
        uploadTitle: 'Enviar arquivos selecionados',
        msgNo: 'N�o',
        msgCancelled: 'Cancelado',
        msgZoomTitle: 'Ver detalhes',
        msgZoomModalHeading: 'Pr�-visualiza��o detalhada',
        msgSizeTooLarge: 'O arquivo "{name}" (<b>{size} KB</b>) excede o tamanho m�ximo permitido de <b>{maxSize} KB</b>.',
        msgFilesTooLess: 'Voc� deve selecionar pelo menos <b>{n}</b> {files} para enviar.',
        msgFilesTooMany: 'O n�mero de arquivos selecionados para o envio <b>({n})</b> excede o limite m�ximo permitido de <b>{m}</b>.',
        msgFileNotFound: 'O arquivo "{name}" n�o foi encontrado!',
        msgFileSecured: 'Restri��es de seguran�a impedem a leitura do arquivo "{name}".',
        msgFileNotReadable: 'O arquivo "{name}" n�o pode ser lido.',
        msgFilePreviewAborted: 'A pr�-visualiza��o do arquivo "{name}" foi interrompida.',
        msgFilePreviewError: 'Ocorreu um erro ao ler o arquivo "{name}".',
        msgInvalidFileType: 'Tipo inv�lido para o arquivo "{name}". Apenas arquivos "{types}" s�o permitidos.',
        msgInvalidFileExtension: 'Extens�o inv�lida para o arquivo "{name}". Apenas arquivos "{extensions}" s�o permitidos.',
        msgUploadAborted: 'O upload do arquivo foi abortada',
        msgValidationError: 'Erro de valida��o',
        msgLoading: 'Enviando arquivo {index} de {files}&hellip;',
        msgProgress: 'Enviando arquivo {index} de {files} - {name} - {percent}% completo.',
        msgSelected: '{n} {files} selecionado(s)',
        msgFoldersNotAllowed: 'Arraste e solte apenas arquivos! {n} soltar pasta(s) ignoradas.',
        msgImageWidthSmall: 'Largura do arquivo de imagem "{name}" deve ser pelo menos {size} px.',
        msgImageHeightSmall: 'Altura do arquivo de imagem "{name}" deve ser pelo menos {size} px.',
        msgImageWidthLarge: 'Largura do arquivo de imagem "{name}" n�o pode exceder {size} px.',
        msgImageHeightLarge: 'Altura do arquivo de imagem "{name}" n�o pode exceder {size} px.',
        msgImageResizeError: 'Could not get the image dimensions to resize.',
        msgImageResizeException: 'Erro ao redimensionar a imagem.<pre>{errors}</pre>',
        dropZoneTitle: 'Drag and drop the file here&hellip;',
        fileActionSettings: {
            removeTitle: 'Remover arquivo',
            uploadTitle: 'Carregar arquivo',
            indicatorNewTitle: 'Ainda n�o carregou',
            indicatorSuccessTitle: 'Carregado',
            indicatorErrorTitle: 'Carregar Erro',
            indicatorLoadingTitle: 'A carregar ...'
        }
    };
})(window.jQuery);